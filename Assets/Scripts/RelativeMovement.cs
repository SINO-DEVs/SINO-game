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

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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

            Quaternion tmp = target.rotation;
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);
            target.rotation = tmp;
            transform.rotation = Quaternion.LookRotation(movement);
            Vector3.ClampMagnitude(movement, moveSpeed * (speedUp ? speedUpMultiplier : 1.0f));
            GetComponent<CharacterController>().Move(movement * Time.deltaTime * moveSpeed * (speedUp ? speedUpMultiplier : 1.0f));
        }
    }
}
