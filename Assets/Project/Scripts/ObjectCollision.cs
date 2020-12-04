using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCollision : MonoBehaviour
{

    private int _value;
    // Start is called before the first frame update
    void Start()
    {
        if (CompareTag("Collectable_0"))
        {
            _value = 2000;
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
            oi.IncreasePointsBy(_value);
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
