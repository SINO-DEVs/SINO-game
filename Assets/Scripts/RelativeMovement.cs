using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeMovement : MonoBehaviour
{
    [SerializeField] private Transform target;

    public float moveSpeed = 6.0f;
    public float speedUpMultiplier = 2.0f;

    private CharacterController _charController;
    private Animator _animator;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        bool speedUp = Input.GetKey(KeyCode.LeftShift);
        _animator.SetBool("isRunning", speedUp);

        Vector3 movement = Vector3.zero;
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        bool idle = horInput == 0 && vertInput == 0;
        _animator.SetBool("idle", idle);

        if (!idle)
        {
            movement.x = horInput;
            movement.z = vertInput;

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
            _charController.Move(movement * Time.deltaTime * moveSpeed * (speedUp ? speedUpMultiplier : 1.0f));
        }
    }

    public void reactToGuard(Transform guard)
    {
        //set parameters for animations
        _animator.SetBool("idle", true);
        _animator.SetBool("isRunning", false);

        // disable movement player
        isDead = true;

        //rotation in y in the direction of the guard
        Quaternion rot = Quaternion.LookRotation(guard.position - transform.position);
        rot.x = 0;
        rot.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.01f);

        //start animation after few moments
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(1.0f);
        _animator.SetBool("isDead", isDead);
    }

}
