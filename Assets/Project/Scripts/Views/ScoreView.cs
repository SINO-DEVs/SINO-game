using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Messenger<int>.AddListener(GameEvent.SCORE_CHANGED, OnScoreChanged);
        OnScoreChanged(ScoreManager.Instance.Score);
    }

    private void OnScoreChanged(int score)
    {
        scoreText.text = $"{score:D9}";
    }

    void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.SCORE_CHANGED, OnScoreChanged);
    }
}
