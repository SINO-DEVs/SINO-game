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

    public int computeSumOfHighestScores()
    {
        return (loadBestScoreFor("Level01") == -1 ? 0 : loadBestScoreFor("Level01")) +
               (loadBestScoreFor("Level02") == -1 ? 0 : loadBestScoreFor("Level02")) +
               (loadBestScoreFor("Level03") == -1 ? 0 : loadBestScoreFor("Level03"));
    }
}
