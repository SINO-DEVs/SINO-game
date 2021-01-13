using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    private Text scoreText;

    private readonly int maxCharPoints = 10;

    private int record;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        Messenger<int>.AddListener(GameEvent.SCORE_CHANGED, OnScoreChanged);
        OnScoreChanged(ScoreManager.Instance.Score);
        record = ScoreRepositoryManager.Instance.loadBestScoreFor(SceneManager.GetActiveScene().name);
    }

    private void OnScoreChanged(int score)
    {
        scoreText.text = String.Format("Record: {0,10:D" + maxCharPoints + "}\n" +
                                       "Points : {1,10:D" + maxCharPoints + "}", record, score);
    }

    void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.SCORE_CHANGED, OnScoreChanged);
    }

}
