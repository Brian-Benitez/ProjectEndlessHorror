using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    public static GameMain instance;

    delegate void AdvanceToNewRoom();
    AdvanceToNewRoom AdvanceToRoomDelegate;

    delegate void JumpScareDelegate();
    JumpScareDelegate PlayJumpScareDelegate;

    delegate void LosingEvent();
    LosingEvent PlayerLostToTimeDelegate;

    delegate void ScaryEventDelegate();
    ScaryEventDelegate PlayScaryEventDelegate;

    [Header("Script")]
    public LevelManager LevelManagerRef;
    public PlayerInventory PlayerInventoryRef;
    public MonsterBehavior MonsterBehaviorRef;  
    public GameTimer GameTimerRef;
    public CameraFade CameraFadeRef;
    public CameraController CameraControllerRef;
    public AudioController AudioControllerRef;

    private void Awake()
    {
        if(instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        //Add changing the level here first before doing whats below
        AdvanceToRoomDelegate += LevelManagerRef.ChangeLevelPrefab;
        AdvanceToRoomDelegate += MonsterBehaviorRef.AddAIndex;
        AdvanceToRoomDelegate += LevelManagerRef.RepositionPlayer;
        AdvanceToRoomDelegate += PlayerInventoryRef.ClearInventoryList;
        AdvanceToRoomDelegate += MonsterBehaviorRef.SpawnMonsterInArea;
        AdvanceToRoomDelegate += GameTimerRef.StartTimerBoolean;
        AdvanceToRoomDelegate += MonsterBehaviorRef.RestartJumpScareBool;
        AdvanceToRoomDelegate += CameraFadeRef.FadeOffOfBlack;

        //Losing game stuff
        PlayerLostToTimeDelegate += LevelManagerRef.RepositionPlayer;
        PlayerLostToTimeDelegate += LevelManagerRef.RestartLevel;
        PlayerLostToTimeDelegate += MonsterBehaviorRef.SpawnMonsterInArea;
        PlayerLostToTimeDelegate += PlayerInventoryRef.ClearInventoryList;
        PlayerLostToTimeDelegate += CameraControllerRef.TurnOnPlayerCam;
        PlayerLostToTimeDelegate += AudioControllerRef.RestartRoundSound;
        PlayerLostToTimeDelegate += GameTimerRef.StartTimerBoolean;
        PlayerLostToTimeDelegate += MonsterBehaviorRef.RestartJumpScareBool;
        PlayerLostToTimeDelegate += CameraFadeRef.FadeOffOfBlack;

        //Jumpscare stuff
        PlayJumpScareDelegate += MonsterBehaviorRef.PlayInstanceJumpScare;

        //Jumpscare scary event
        PlayScaryEventDelegate += MonsterBehaviorRef.SpawnMonsterInArea;
        PlayScaryEventDelegate += MonsterBehaviorRef.EnableObject;
        PlayScaryEventDelegate += MonsterBehaviorRef.StartMonsterMovement;
    }
    /// <summary>
    /// Plays a delegate event to advance to the next room.
    /// </summary>
    public void AdvanceToNextLevel() => AdvanceToRoomDelegate?.Invoke();

    /// <summary>
    /// Plays the deleagte event to play the losing event.
    /// </summary>
    public void PlayLostViaTimeDelegate() => PlayerLostToTimeDelegate?.Invoke();

    /// <summary>
    /// Plays the delegate event to jump scare the player.
    /// </summary>
    public void PlayingJumpScareDelegate() => PlayJumpScareDelegate?.Invoke();
    /// <summary>
    /// Play the scary encounter
    /// </summary>
    public void PlayingScaryEventDelegate()
    {
        if (LevelManagerRef.LevelIndex == 4)
            PlayScaryEventDelegate?.Invoke();
        else
            Debug.Log("can't play scary event yet");
    }
}
