using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCollision : MonoBehaviour
{
    private int value;

    // Start is called before the first frame update
    void Start()
    {
        if (CompareTag("Collectable_0"))
        {
            value = 10000;
        } else if (CompareTag("Collectable_1"))
        {
            value = 5000;
        } else if (CompareTag("Collectable_2"))
        {
            value = 2500;
        }
        else if (CompareTag("Collectable_3"))
        {
            value = 1250;
        }
        else if (CompareTag("Collectable_4"))
        {
            value = 500;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Messenger<int>.Broadcast(GameEvent.SCORE_INCREMENTED, value, MessengerMode.DONT_REQUIRE_LISTENER);
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
        waitFor(0.5f);
    }

    private IEnumerator waitFor(float s)
    {
        yield return new WaitForSeconds(s);
    }
}
