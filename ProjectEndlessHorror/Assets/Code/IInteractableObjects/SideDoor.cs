using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDoor : MonoBehaviour, IInteractable
{
    public PlayerInventory PlayerInventoryRef;
    public LevelManager LevelManagerRef;
    public MonsterBehavior MonsterBehaviorRef;
    public void Interact()
    {
        PlayerInventoryRef.PlayersInventoryList.Add(transform.gameObject);

        if (PlayerInventoryRef.DoesPlayerHaveSecondDoorKey())
            LevelManagerRef.RotateSideDoor();
        else
            Debug.Log("player does not have a second door key");

        GameMain.instance.PlayingScaryEventDelegate();//This is the event playing for when its level four and the scary event will play.

        if(LevelManagerRef.LevelIndex == 4)//this is for the "deletion" of the key.
            transform.gameObject.SetActive(false);
    }
}
