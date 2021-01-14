using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGiver : MonoBehaviour
{
    public float rotation;
    public bool alternate = false;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private IEnumerator OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy") && !isActive)
        {
            isActive = true;
            collider.GetComponent<Transform>().Rotate(Vector3.up * rotation);

            if (alternate)
            {
                this.transform.Rotate(Vector3.up * rotation);
                rotation *= -1;
            }

            yield return new WaitForSeconds(1.0f);
            isActive = false;
        }
        
    }
}
