using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelLoader : MonoBehaviour
{
    UnityEngine.UI.Text score;
    // GUIText score;
    void Start()
    {
        loadScore();
    }

    void loadScore()
    {
        //Find the GameObject named Best in the scene
        GameObject scoreGameObject = GameObject.Find("ScoreView");

        //Get the GUIText Component attached to that GameObject named Best
        score = scoreGameObject.GetComponent<UnityEngine.UI.Text>();

        //Load score
        // PlayerPrefs.GetInt("highscore", 0)
        score.text = "Score: " + ScoreManager.Instance.Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
