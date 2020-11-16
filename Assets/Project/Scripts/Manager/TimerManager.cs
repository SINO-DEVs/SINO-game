using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour, IGameManager
{
    private float timerSec;
    private DateTime start;

    public static TimerManager Instance = null;

    void Awake()
    {
        Instance = this;
    }

    public ManagerStatus _Status { get; set; } = ManagerStatus.SHUTDOWN;

    public void Startup()
    {
        _Status = ManagerStatus.INITIALIZING;
        start = DateTime.Now;
        _Status = ManagerStatus.STARTED;
    }

    void Update()
    {
        if (!LifeManager.Instance.Alive)
        {
            return;
        }

        timerSec += Time.deltaTime;
        if (timerSec > 1)
        {
            timerSec = 0;
            Messenger<int>.Broadcast(GameEvent.SCORE_INCREMENTED, -1, MessengerMode.DONT_REQUIRE_LISTENER);

            var elapsed = DateTime.Now - start;
            Messenger<TimeSpan>.Broadcast(GameEvent.TIMER_CHANGED, elapsed, MessengerMode.DONT_REQUIRE_LISTENER);
        }

    }

}
