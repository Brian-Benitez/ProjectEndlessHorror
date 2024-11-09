using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour, IInteractable
{
    public PlayerInventory PlayerInventoryRef;
    public LevelManager LevelManagerRef;
    public void Interact()
    {
        PlayerInventoryRef.PlayersInventoryList.Add(transform.gameObject);
        Debug.Log("added key to inventory");
        LevelManagerRef.RotateSideDoor();
        GameMain.instance.PlayingScaryEventDelegate();//This is the event playing for when its level four and the scary event will play.
        transform.gameObject.SetActive(false);//set 
    }
}
