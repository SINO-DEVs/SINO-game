using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text highestScore = null;
    public int offset;
    [SerializeField] private Button levelChosen;


    void Start()
    {
        loadHighestScore();

        //Find the GameObject named Best in the scene
        GameObject nextLevelGameObject = GameObject.Find("Level0"+offset);
        if (nextLevelGameObject != null) {
            levelChosen = nextLevelGameObject.GetComponent<Button>();
            levelChosen.onClick.AddListener(chooseLevel);
            if (offset == 1)
                return;
            int result = PlayerPrefs.GetInt("Level0" + offset, -1);
            int previousLevel = PlayerPrefs.GetInt("Level0" + (offset-1), -1);
            if (result == -1 && previousLevel==-1)
                levelChosen.interactable=false;
        }
    }

    public void chooseLevel() {
        SceneManager.LoadScene(offset);
        Levels.Instance.setOffset(offset);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(offset);
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
