using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TimerView : MonoBehaviour
{
    private Text timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Text>();
        Messenger<TimeSpan>.AddListener(GameEvent.TIMER_CHANGED, OnTimerChanged);
    }

    private void OnTimerChanged(TimeSpan elapsed)
    {
        timer.text = "Time: " + elapsed.ToString("mm':'ss");
    }

    void OnDestroy()
    {
        Messenger<TimeSpan>.RemoveListener(GameEvent.TIMER_CHANGED, OnTimerChanged);
    }

    
}
