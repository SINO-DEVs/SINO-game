using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text highestScore = null;

    void Start()
    {
        loadHighestScore();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void loadHighestScore()
    {
        //Find the GameObject named Best in the scene
        GameObject highestScoreGameObject = GameObject.Find("HighestScore");

        //Get the GUIText Component attached to that GameObject named Best
        highestScore = highestScoreGameObject.GetComponent<Text>();

        //Load the sum of highest scores
        highestScore.text = "Highest Score: " + ScoreRepositoryManager.Instance.computeSumOfHighestScores();
    }
}
