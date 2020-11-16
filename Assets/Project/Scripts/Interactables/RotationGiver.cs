using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGiver : MonoBehaviour
{
    public float rotation;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            collider.GetComponent<Transform>().Rotate(Vector3.up * rotation);
        }
        
    }
}
