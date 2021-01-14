using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour, IGameManager
{    
    public static LifeManager Instance = null;

    private bool _alive;
    public bool Alive
    {
        get => _alive;
    }

    void Awake()
    {
        Instance = this;
    }

    public ManagerStatus _Status { get; set; } = ManagerStatus.SHUTDOWN;

    public void Startup()
    {
        _Status = ManagerStatus.INITIALIZING;
        _alive = true;
        Messenger<bool>.AddListener(GameEvent.PLAYER_DEATH, changeAlive);
        _Status = ManagerStatus.STARTED;
    }

    private void changeAlive(bool isDead)
    {
        _alive = !isDead;
    }

}
