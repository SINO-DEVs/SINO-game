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
            value = 2000;
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
        displayWinScreen();
    }

    private IEnumerator waitFor(float s)
    {
        yield return new WaitForSeconds(s);
    }

    private void displayWinScreen()
    {
        SceneManager.LoadScene("WinScreen");
    }
}
