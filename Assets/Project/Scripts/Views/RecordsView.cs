using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class RecordsView : MonoBehaviour
{
    private Text scores;

    private readonly int maxCharPoints = 10;

    // Start is called before the first frame update
    void Start()
    {
        scores = GetComponent<Text>();
        scores.text = String.Format("Level 1: {0,10:D" + maxCharPoints + "}\n" +
                                    "Level 2: {1,10:D" + maxCharPoints + "}\n" +
                                    "Level 3: {2,10:D" + maxCharPoints + "}",
                                    ScoreRepositoryManager.Instance.loadBestScoreFor("Level01"),
                                    ScoreRepositoryManager.Instance.loadBestScoreFor("Level02"),
                                    ScoreRepositoryManager.Instance.loadBestScoreFor("Level03"));
    }

    
}
