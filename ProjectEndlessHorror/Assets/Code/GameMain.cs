using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour//make this into a singlton?
{
    delegate void AdvanceToNewRoom();
    AdvanceToNewRoom AdvanceToRoom;
    //Add more events here....

    [Header("Script")]
    public LevelManager LevelManagerRef;
    public PlayerInventory PlayerInventoryRef;

    private void Start()
    {
        //Add changing the level here first before doing whats below
        AdvanceToRoom += LevelManagerRef.RepositionPlayer;
        AdvanceToRoom += PlayerInventoryRef.ClearInventoryList;
    }

    public void AdvanceToNextLevel()
    {
        AdvanceToRoom?.Invoke();
    }

}
