using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [Header("Game Manager Parameter")]
    public bool IsGameFinished = false;

    public static GameMain instance;

    delegate void AdvanceToNewRoom();
    AdvanceToNewRoom AdvanceToRoomDelegate;

    delegate void JumpScareDelegate();
    JumpScareDelegate PlayJumpScareDelegate;

    delegate void LosingEvent();
    LosingEvent PlayerLostToTimeDelegate;

    delegate void ScaryEventDelegate();
    ScaryEventDelegate PlayScaryEventDelegate;

    delegate void RestartGameLogic();
    RestartGameLogic PlayRestartGameLogicDelegate;

    [Header("Script")]
    public LevelManager LevelManagerRef;
    public PlayerInventory PlayerInventoryRef;
    public MonsterBehavior MonsterBehaviorRef;  
    public GameTimer GameTimerRef;
    public CameraFade CameraFadeRef;
    public CameraController CameraControllerRef;
    public MonsterMovement MonsterMovementRef;  
    public LorePages LorePagesRef;
    public MonsterAnimations MonsterAnimationsRef;
    public StartChaseSequnce StartChaseSequnceRef;
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
        AdvanceToRoomDelegate += LorePagesRef.SwitchPlaces;
        AdvanceToRoomDelegate += MonsterBehaviorRef.AddAIndex;
        AdvanceToRoomDelegate += LevelManagerRef.RepositionPlayer;
        AdvanceToRoomDelegate += PlayerInventoryRef.ClearInventoryList;
        AdvanceToRoomDelegate += MonsterBehaviorRef.SpawnMonsterInArea;
        AdvanceToRoomDelegate += GameTimerRef.StartTimerBoolean;
        AdvanceToRoomDelegate += MonsterBehaviorRef.RestartJumpScareBool;
        AdvanceToRoomDelegate += CameraFadeRef.FadeOffOfBlack;
        AdvanceToRoomDelegate += AudioController.instance.PlayCertainSoundsOnLvlThree;
        AdvanceToRoomDelegate += AudioController.instance.PlayingLevelVO;

        //Losing game stuff
        PlayerLostToTimeDelegate += LevelManagerRef.RepositionPlayer;
        PlayerLostToTimeDelegate += MonsterAnimationsRef.StopJumpScareAnimation;
        PlayerLostToTimeDelegate += CameraControllerRef.TurnOffTimedJumpScareCam;
        PlayerLostToTimeDelegate += CameraControllerRef.InstanceJumpScareCamOff;
        PlayerLostToTimeDelegate += MonsterMovementRef.TurnOffMonstersNavMesh;
        PlayerLostToTimeDelegate += LevelManagerRef.RestartLevel;
        PlayerLostToTimeDelegate += MonsterBehaviorRef.SpawnMonsterInArea;
        PlayerLostToTimeDelegate += PlayerInventoryRef.ClearInventoryList;
        PlayerLostToTimeDelegate += CameraControllerRef.TurnOnPlayerCam;
        PlayerLostToTimeDelegate += AudioController.instance.RestartRoundSound;
        PlayerLostToTimeDelegate += GameTimerRef.StartTimerBoolean;
        PlayerLostToTimeDelegate += MonsterBehaviorRef.RestartJumpScareBool;
        PlayerLostToTimeDelegate += CameraFadeRef.FadeOffOfBlack;

        //Jumpscare stuff
        PlayJumpScareDelegate += MonsterBehaviorRef.PlayInstanceJumpScare;
        PlayJumpScareDelegate += AudioController.instance.JumpScareSoundPlay;
        PlayJumpScareDelegate += LevelManagerRef.RestartGameKeys;

        //Jumpscare Chasing scene scary event 
        PlayScaryEventDelegate += MonsterBehaviorRef.SpawnMonsterInArea;
        PlayScaryEventDelegate += MonsterBehaviorRef.EnableObject;
        PlayScaryEventDelegate += MonsterBehaviorRef.StartMonsterMovement;

        //Restarting game logic
        PlayRestartGameLogicDelegate += LevelManagerRef.RestartGameKeys;
        PlayRestartGameLogicDelegate += LevelManagerRef.ChangeLevelPrefab;//this will put the player in the first actual level not the "tutorial"
        PlayRestartGameLogicDelegate += LevelManagerRef.RepositionPlayer;
        PlayRestartGameLogicDelegate += StartChaseSequnceRef.TurnOffChaseBool;
        PlayRestartGameLogicDelegate += MonsterBehaviorRef.RestartMonstersBehavior;
        PlayRestartGameLogicDelegate += MonsterMovementRef.TurnOffMonstersNavMesh;
        PlayRestartGameLogicDelegate += MonsterBehaviorRef.SpawnMonsterInArea;
        PlayRestartGameLogicDelegate += MonsterBehaviorRef.RestartJumpScareBool;
        PlayRestartGameLogicDelegate += PlayerInventoryRef.ClearInventoryList;
        PlayRestartGameLogicDelegate += GameTimerRef.StartTimerBoolean;
        PlayRestartGameLogicDelegate += LorePagesRef.SwitchPlaces;
        PlayRestartGameLogicDelegate += CameraFadeRef.FadeOffOfBlack;
        PlayRestartGameLogicDelegate += AudioController.instance.PlayingLevelVO;
        PlayRestartGameLogicDelegate += GameIsFinishedSetFalse;
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

    public void PlayingRestartGameLogicDelegate() => PlayRestartGameLogicDelegate?.Invoke();  
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
    public void GameIsFinishedSetTrue() => IsGameFinished = true;
    public void GameIsFinishedSetFalse() => IsGameFinished = false;
}
