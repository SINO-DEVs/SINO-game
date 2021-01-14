using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    // To check when the main character die
    [SerializeField]
    public bool isDead = false;

    public bool shot = false;

    [SerializeField] private Transform target = null;
    private CharacterController charController;
    private Animator animator;

    [SerializeField] private float moveSpeed = 6.0f;
    [SerializeField] private float speedUpMultiplier = 2.0f;
    private readonly float gravity = -9.81f;


    private float footstepDistanceCounter = 1.0f;
    private float footstepFrequencyWhileSprinting = 4.0f;
    private float footstepFrequency = 3.0f;


    private Vector3 characterVelocity;


    private float yVelocity = 0.0f;

    // Start is called before the first frame update
    void Start() {
        charController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        //start the extradiegetic sound
        FindObjectOfType<AudioManager>().Play("Level01Extradiegetic");
    }

    // Update is called once per frame
    void Update() {
        if (!LifeManager.Instance.Alive)
            return;

        bool speedUp = Input.GetKey(KeyCode.LeftShift);
        animator.SetBool("isRunning", speedUp);

        Vector3 movement = Vector3.zero;
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        bool idle = horInput == 0 && vertInput == 0;
        animator.SetBool("idle", idle);

        // if enter the if then character is moving
        if (!idle) {
            movement.x = horInput;
            movement.z = vertInput;

            if (CameraSwitchManager.Instance.ThirdPActive) {
                //create movement vector from camera perspective
                Quaternion tmp = target.rotation;
                target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
                movement = target.TransformDirection(movement);
                target.rotation = tmp;

                //rotation payer
                Quaternion to = Quaternion.LookRotation(movement);
                transform.rotation = Quaternion.Slerp(transform.rotation, to, 0.1f);

                //movement palyer
                Vector3.ClampMagnitude(movement, moveSpeed * (speedUp ? speedUpMultiplier : 1.0f));
                charController.Move(movement * Time.deltaTime * moveSpeed * (speedUp ? speedUpMultiplier : 1.0f));
            } else {
                charController.Move(transform.forward * movement.z * Time.deltaTime * moveSpeed * (speedUp ? speedUpMultiplier : 1.0f));
                charController.Move(transform.right * movement.x * Time.deltaTime * moveSpeed * (speedUp ? speedUpMultiplier : 1.0f));
            }

            // Start the sound that simulates the footsteps
            FootSteps(speedUp, movement);
        }

        //gravity for stairs
        if (!charController.isGrounded) {
            movement = Vector3.zero;
            yVelocity += gravity;
            movement.y = yVelocity;
            charController.Move(movement * Time.deltaTime);
        } else {
            yVelocity = 0.0f;
        }

    }

    private void FootSteps(bool speedUp, Vector3 movement) {
        float chosenFootstepFrequency = (speedUp ? footstepFrequencyWhileSprinting : footstepFrequency);

        if (footstepDistanceCounter >= 1f / chosenFootstepFrequency) {
            FindObjectOfType<AudioManager>().PlayOneShot("FootStepSound", speedUp ? 1f : .5f);
            footstepDistanceCounter = 0f;
        }

        footstepDistanceCounter += movement.magnitude * Time.deltaTime;
    }

    public void ReactToGuard(Transform guard) {
        //set parameters for animations
        animator.SetBool("idle", true);
        animator.SetBool("isRunning", false);

        //set the dead flag to true
        isDead = true;

        //stop the extradiegetic sound
        FindObjectOfType<AudioManager>().Stop("Level01Extradiegetic");

        // Start the fail sound
        StartCoroutine(FailSound());

        //rotation in y in the direction of the guard
        Quaternion rot = Quaternion.LookRotation(guard.position - transform.position);
        rot.x = 0;
        rot.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.01f);
        Messenger<bool>.Broadcast(GameEvent.PLAYER_DEATH, true, MessengerMode.DONT_REQUIRE_LISTENER);

        //start animation after few moments
        StartCoroutine(Die());
    }

    private IEnumerator FailSound() {
        yield return new WaitForSeconds(1);
        if (!FindObjectOfType<AudioManager>().isPlaying("LoseSound"))
            FindObjectOfType<AudioManager>().Play("LoseSound");
    }

    private IEnumerator Die() {
        yield return new WaitForSeconds(.6f);
        animator.SetBool("isDead", !LifeManager.Instance.Alive);

        // Play the shot-gun of the police
        StartCoroutine(ShotGunSound());

        yield return new WaitForSeconds(1.0f);
        Levels.Instance.displayGameOver();
    }

    private IEnumerator ShotGunSound() {
        yield return new WaitForSeconds(0);
        if (!FindObjectOfType<AudioManager>().isPlaying("ShotGunSound") && !shot) {
            FindObjectOfType<AudioManager>().Play("ShotGunSound");
            shot = true;
        }
    }
}
