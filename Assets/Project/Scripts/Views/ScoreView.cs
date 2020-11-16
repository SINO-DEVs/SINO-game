using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    private Text scoreText;

    private readonly int maxCharPoints = 10;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        Messenger<int>.AddListener(GameEvent.SCORE_CHANGED, OnScoreChanged);
        OnScoreChanged(ScoreManager.Instance.Score);
    }

    private void OnScoreChanged(int score)
    {
        scoreText.text = String.Format("{0,10:D" + maxCharPoints + "}", score);
    }

    void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.SCORE_CHANGED, OnScoreChanged);
    }

}
