using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class RecordsView : MonoBehaviour
{
    private Text scores;
    public int level;

    private readonly int maxCharPoints = 10;

    // Start is called before the first frame update
    void Start()
    {
        scores = GetComponent<Text>();
        scores.text = String.Format("Level "+level+": {0,10:D" + maxCharPoints + "}\n",
                                   Math.Max(ScoreRepositoryManager.Instance.loadBestScoreFor("Level0"+level), 0));
    }

    
}
