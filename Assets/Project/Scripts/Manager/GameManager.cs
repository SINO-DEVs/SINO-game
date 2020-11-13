using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class GameManager
{
    // make sure the constructor is private, so it can only be instantiated here
    private GameManager()
    {
        _playerName = PlayerPrefs.GetString("PlayerName", "UNKNOWN");
        MaxLife = PlayerPrefs.GetInt("MaxLife", 3);
        _highScores = PlayerPrefs.GetString("HighScore", "{}");
        InputInteraction = false;
    }

    public bool InputInteraction { get; set; }

    public static GameManager Instance { get; } = new GameManager();

    private string _playerName;

    public string PlayerName
    {
        get => _playerName;
        set
        {
            PlayerPrefs.SetString("PlayerName", value);
            _playerName = value;
        }
    }

    private int _maxLife;

    public int MaxLife
    {
        get => _maxLife;
        set
        {
            _maxLife = value;
            PlayerPrefs.SetInt("MaxLife", value);
        }
    }

    private string _highScores;

    public Dictionary<string, int> HighScores
    {
        get => JsonConvert.DeserializeObject<Dictionary<string, int>>(_highScores);
        set
        {
            _highScores = JsonConvert.SerializeObject(value);
            PlayerPrefs.SetString("HighScores", _highScores);
        }
    }
}