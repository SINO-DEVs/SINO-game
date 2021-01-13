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
        Button button = backToMenu.GetComponent<Button>();
        button.onClick.AddListener(goToMenu);
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
