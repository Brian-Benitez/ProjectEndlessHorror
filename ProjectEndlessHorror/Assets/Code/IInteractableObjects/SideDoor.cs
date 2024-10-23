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
        if (PlayerInventoryRef.DoesPlayerHaveSecondDoorKey())//wtf does this doo
            LevelManagerRef.RotateSideDoor();
        else
            Debug.Log("player does not have a second door key");

        MonsterBehaviorRef.SpawnMonsterInArea();
        MonsterBehaviorRef.EnableObject();
        MonsterBehaviorRef.StartMonsterMovement();
    }
}
