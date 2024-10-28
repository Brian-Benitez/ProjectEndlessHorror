using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float TimeRemaining = 5;
    public bool TimerIsRunning = false;

    private void Start()
    {
        TimerIsRunning = true; 
    }

    private void Update()
    {
        if(TimerIsRunning)
        {
            if (TimeRemaining > 0)
                TimeRemaining -= Time.deltaTime;
            else
            {
                Debug.Log("time is ran out.");
                TimeRemaining = 0;
                TimerIsRunning = false;
            }
        }
    }

    public void StartTimerBoolean()
    {
        TimerIsRunning = true;
        TimeRemaining = 300f;
    }
    public void EndTimerBoolean() => TimerIsRunning = false;
}
