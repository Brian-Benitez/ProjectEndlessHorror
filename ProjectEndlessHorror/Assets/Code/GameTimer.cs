using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [Header("Game timer info")]
    public float TimeRemaining = 5;
    public bool TimerIsRunning = false;

    [Header("Scripts")]
    public MonsterBehavior MonsterBehaviorRef;

    private void Start() => TimerIsRunning = true;

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
                MonsterBehaviorRef.TimedMonsterJumpScare();
            }
        }
    }

    public void StartTimerBoolean()
    {
        TimerIsRunning = true;
        TimeRemaining = 300f;
    }
}
