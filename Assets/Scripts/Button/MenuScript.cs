using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Button backToMenu;

    // Start is called before the first frame update
    void Start()
    {
        //Find the GameObject named Best in the scene
        GameObject nextLevelGameObject = GameObject.Find("MenuButton");
        backToMenu = nextLevelGameObject.GetComponent<Button>();
        backToMenu.onClick.AddListener(goToMenu);
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
