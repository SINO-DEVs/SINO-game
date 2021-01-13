using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRepositoryManager : MonoBehaviour
{
    public static ScoreRepositoryManager Instance = null;

    void Awake()
    {
        Instance = this;
    }

    public void updateScoreIfGreater(string name, int score)
    {
        int persisted = loadBestScoreFor(name);
        if (score > persisted)
            saveScoreFor(name, score);
    }

    private void saveScoreFor(string name, int score)
    {
        PlayerPrefs.SetInt(name, score);
    }

    public int loadBestScoreFor(string name)
    {
        return PlayerPrefs.GetInt(name, -1);
    }
}
