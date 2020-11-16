using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IGameManager
{
    [SerializeField] private int _score;
    public int Score
    {
        get => _score;
    }
    
    public static ScoreManager Instance = null;

    void Awake()
    {
        Instance = this;
    }

    public ManagerStatus _Status { get; set; } = ManagerStatus.SHUTDOWN;

    public void Startup()
    {
        _Status = ManagerStatus.INITIALIZING;
        _score = 100;
        Messenger<int>.AddListener(GameEvent.SCORE_INCREMENTED, ChangeScore);
        _Status = ManagerStatus.STARTED;
    }

    private void ChangeScore(int quantity)
    {
        _score += quantity;
        int scoreToShow = Mathf.Clamp(_score, 0, 999999999);
        
        // Broadcast score changed event
        Messenger<int>.Broadcast(GameEvent.SCORE_CHANGED, scoreToShow, MessengerMode.DONT_REQUIRE_LISTENER);
    }
    
    void onDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.SCORE_INCREMENTED, ChangeScore);
    }

}
