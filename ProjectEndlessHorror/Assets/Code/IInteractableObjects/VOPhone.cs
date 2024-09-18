using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VOPhone : MonoBehaviour, IInteractable
{
    public MonsterBehavior monsterBehavior;
    public void Interact()
    {
        Puzzles puzzles = FindObjectOfType<Puzzles>();
        //puzzles.ClickedOnVOPhone = true;
        Debug.Log("monsterrrrrrrrr");
        monsterBehavior.MonsterPrefab.transform.position = monsterBehavior.MonsterSpawnIn.transform.position;
        monsterBehavior.MonsterPrefab.SetActive(true);
    }
}
