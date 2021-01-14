using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryScript : MonoBehaviour
{
    public Button retry;

    // Start is called before the first frame update
    void Start()
    {
        //Find the GameObject named Best in the scene
        GameObject retryGameObject = GameObject.Find("RetryButton");
        retry = retryGameObject.GetComponent<Button>();
        retry.onClick.AddListener(Levels.Instance.retry);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
