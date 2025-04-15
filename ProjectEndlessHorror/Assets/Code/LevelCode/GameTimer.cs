using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [Header("Game timer info")]
    public float TimeRemaining = 5;
    public float SetTimer = 250f;
    public bool TimerIsRunning = false;
    public bool PauseTimer = false; 
    public bool IsFinalMintue = false;

    [Header("Scripts")]
    public MonsterBehavior MonsterBehaviorRef;
    public EasterEggController EasterEggControllerRef;

    private void Start() => TimerIsRunning = true;

    private void Update()
    {
        if(PauseTimer)
            return;
        else if(TimerIsRunning && !PauseTimer)
        {
            if (EasterEggControllerRef.IsEasterEggEnabled == true)
                return;
            else
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
    }
    public void StartTimerBoolean()
    {
        UnPauseTheGameTimer();
        TimerIsRunning = true;
        IsFinalMintue = false;
        TimeRemaining = SetTimer;
    }
    private void PlaySound()
    {
        IsFinalMintue = true;
        AudioController.instance.FinalMinuteSound();
    }
    public void PauseTheGameTimer() => PauseTimer = true;
    private void UnPauseTheGameTimer() => PauseTimer = false;
}
