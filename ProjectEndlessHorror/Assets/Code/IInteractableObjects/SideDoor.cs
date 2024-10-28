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

        if(LevelManagerRef.LevelIndex == 4)///this is the key
        {
            MonsterBehaviorRef.SpawnMonsterInArea();
            MonsterBehaviorRef.EnableObject();
            MonsterBehaviorRef.StartMonsterMovement();
            transform.gameObject.SetActive(false); 
        }
    }
}
