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
    LosingEvent PlayerLoseDelegate;

    [Header("Script")]
    public LevelManager LevelManagerRef;
    public PlayerInventory PlayerInventoryRef;

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
        AdvanceToRoomDelegate += LevelManagerRef.RepositionPlayer;
        AdvanceToRoomDelegate += PlayerInventoryRef.ClearInventoryList;

        PlayerLoseDelegate += LevelManagerRef.RestartLevel;
    }
    /// <summary>
    /// Plays a delegate event to advance to the next room.
    /// </summary>
    public void AdvanceToNextLevel() => AdvanceToRoomDelegate?.Invoke();

    /// <summary>
    /// Plays the deleagte event to play the losing event.
    /// </summary>
    public void PlayLosingDelegate() => PlayerLoseDelegate?.Invoke();

    /// <summary>
    /// Plays the delegate event to jump scare the player.
    /// </summary>
    public void PlayingJumpScareDelegate() => PlayJumpScareDelegate?.Invoke();

}
