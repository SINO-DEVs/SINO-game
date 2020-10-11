using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float moveSpeed = 6.0f;
    public float gravity = -9.8f;
    private CharacterController _charController;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        float horInput = -Input.GetAxis("Horizontal");
        float vertInput = -Input.GetAxis("Vertical");

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
