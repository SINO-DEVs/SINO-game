using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public static Levels Instance = null;
    private int offset;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void retry()
    {
        SceneManager.LoadScene(offset);
    }

    public void loadNextScene()
    {
        Scene nextScene = SceneManager.GetSceneAt(offset + 1);

        bool isNotWinAndLooseScreens = nextScene != SceneManager.GetSceneByName("WinScreen") && nextScene != SceneManager.GetSceneByName("GameOver");
        if (isNotWinAndLooseScreens)
        {
            offset++;
            SceneManager.LoadScene(offset);
        }
        else
        {
            Debug.Log("Game completed");
            // Handle end of the entire game
            displayMenu();
        }
    }

    public void displayWinScreen()
    {
        Debug.Log(this);
        SceneManager.LoadScene("WinScreen");
    }

    public void displayGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void displayMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public int getOffset()
    {
        return offset;
    }
}
