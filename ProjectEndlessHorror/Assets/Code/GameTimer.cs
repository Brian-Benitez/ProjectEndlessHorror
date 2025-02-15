using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [Header("Game timer info")]
    public float TimeRemaining = 5;
    public bool TimerIsRunning = false;
    public bool IsFinalMintue = false;

    [Header("Scripts")]
    public MonsterBehavior MonsterBehaviorRef;
    public AudioController AudioControllerRef;

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

            if (TimeRemaining <= 60f)
                if (!IsFinalMintue)
                    PlaySound();
        }
    }
    public void StartTimerBoolean()
    {
        TimerIsRunning = true;
        IsFinalMintue = false;
        TimeRemaining = 300f;
    }
    private void PlaySound()
    {
        IsFinalMintue = true;
        AudioControllerRef.FinalMintueSound();
    }
}
