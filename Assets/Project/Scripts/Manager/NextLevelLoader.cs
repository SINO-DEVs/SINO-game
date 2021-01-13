using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextLevelLoader : MonoBehaviour
{
    [SerializeField] private Text score;
    [SerializeField] private Button nextLevelButton;

    void Start()
    {
        loadScore();

        //Find the GameObject named Best in the scene
        GameObject nextLevelGameObject = GameObject.Find("NextLevelButton");
        nextLevelButton = nextLevelGameObject.GetComponent<Button>();
        Debug.Log(nextLevelButton);
        Debug.Log(Levels.Instance);
        nextLevelButton.onClick.AddListener(Levels.Instance.loadNextScene);
    }

    void loadScore()
    {
        //Find the GameObject named Best in the scene
        GameObject scoreGameObject = GameObject.Find("ScoreView");

        //Get the GUIText Component attached to that GameObject named Best
        score = scoreGameObject.GetComponent<Text>();

        //Load score
        score.text = "Score: " + ScoreManager.Instance.Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
