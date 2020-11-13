using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    private int value;

    // Start is called before the first frame update
    void Start()
    {
        if (CompareTag("Collectable_0"))
        {
            value = 2000;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ObjectsInteraction oi = other.GetComponent<ObjectsInteraction>();
        if (oi != null)
        {
            oi.IncreasePointsBy(value);
        }
        Destroy(this.gameObject);
    }
}
