using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour//make this into a singlton?
{
    public static GameMain instance;

    delegate void AdvanceToNewRoom();
    AdvanceToNewRoom AdvanceToRoomEvent;

    delegate void JumpScareDelegate();
    JumpScareDelegate JumpScareEvent;

    delegate void LosingEvent();
    LosingEvent PlayerLoseEvent;

    [Header("Script")]
    public LevelManager LevelManagerRef;
    public PlayerInventory PlayerInventoryRef;

    private void Awake()
    {
        if(instance != null && instance!= this)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        //Add changing the level here first before doing whats below
        AdvanceToRoomEvent += LevelManagerRef.RepositionPlayer;
        AdvanceToRoomEvent += PlayerInventoryRef.ClearInventoryList;
    }
    /// <summary>
    /// Plays a delegate event to advance to the next room.
    /// </summary>
    public void AdvanceToNextLevel() => AdvanceToRoomEvent?.Invoke();

    /// <summary>
    /// Plays the deleagte event to play the losing event.
    /// </summary>
    public void PlayLosingDelegate() => PlayerLoseEvent?.Invoke();

    /// <summary>
    /// Plays the delegate event to jump scare the player.
    /// </summary>
    public void PlayJumpScareDelegate() => JumpScareEvent?.Invoke();

}
