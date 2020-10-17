using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float moveSpeed = 6.0f;
    public float gravity = -9.8f;

    private CharacterController _charController;
    private Animator _animator;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;
        float horInput = -Input.GetAxis("Horizontal");
        float vertInput = -Input.GetAxis("Vertical");
        _animator.SetBool("isRunning", true);
        if (horInput != 0 || vertInput != 0)
        {
            movement.x = horInput * moveSpeed;
            movement.z = vertInput * moveSpeed;
            
            Vector3.ClampMagnitude(movement, moveSpeed);
            //…
        }
        movement *= Time.deltaTime;
        _charController.Move(movement);
    }
}
