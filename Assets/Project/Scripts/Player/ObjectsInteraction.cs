using System;
using UnityEngine;
using UnityEngine.UI;

public class ObjectsInteraction : MonoBehaviour
{
    public bool Running;

    [SerializeField] private Text pointsText;
    [SerializeField] private Text timer;

    /*
     * points can't go below 0
     * points cant show a number bigger than a 10 digit number
     */
    private long _points;
    public long Points
    {
        get
        {
            if (_points < 0)
            {
                return 0;
            }

            if (_points.ToString().Length > maxCharPoints)
            {
                String strPoints = "";
                for (int i = 0; i < maxCharPoints; i++)
                {
                    strPoints += "9";
                }
                return long.Parse(strPoints);
            }

            return _points;
        }
    }
    private readonly int maxCharPoints = 10;

    private float timerSec;
    private DateTime start;

    void Start()
    {
        _points = 100;
        timerSec = 0;
        Running = true;
        start = DateTime.Now;
    }

    void Update()
    {
        if (!Running)
        {
            return;
        }

        var elapsed = DateTime.Now - start;
        timer.text = "Time: " + elapsed.ToString("mm':'ss");

        pointsText.text = String.Format("{0,10:D" + maxCharPoints + "}", Points);

        timerSec += Time.deltaTime;
        if (timerSec > 1)
        {
            timerSec = 0;
            DecreasePointsBy(1);
        }
    }

    public void IncreasePointsBy(int value)
    {
        _points += value;
    }

    public void DecreasePointsBy(int value)
    {
        _points -= value;

        if (_points < 0)
        {
            _points = 0;
        }
    }

}
