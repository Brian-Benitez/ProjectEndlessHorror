using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Transforms")]
    public Transform Player;
    public Transform PlayerSpawnPoint;

    public GameObject Monster;

    [Header("GameObjects")]
    public List<GameObject> LevelPrefabs;
    public GameObject SecuritySecondDoorPrefab;
    public GameObject GlassDoorSecondDoorPrefabTwo;
    public GameObject LevelThreeDoorPrefab;
    public GameObject KeyInVendingMachine;
    public List<GameObject> AllKeysInAllRooms;
    public GameObject FinalKeyObject;

    public List<GameObject> ToiletStalls;
    public GameObject JumpScareTriggerBox;

    [Header("Indexs")]
    public int LevelIndex = 0;
    public int _levelCountMax = 4;//this is counting startting from 0

    [Header("Scripts")]
    public MonsterBehavior MonsterBehaviorRef;
    public GameTimer GameTimerRef;

    private void Start() => KeyInVendingMachine.gameObject.SetActive(false);

    public void ChangeLevelPrefab()
    {
        if (MonsterBehaviorRef.GotJumpScared)
            return;
        else if (LevelIndex == _levelCountMax)
        {
            LevelPrefabs[LevelIndex].SetActive(false);
            LevelIndex = 0;
            LevelPrefabs[LevelIndex].SetActive(true);
            Debug.Log("restart");
        }
        else
        {
            Debug.Log("what the old index "  +  LevelIndex);    
            LevelPrefabs[LevelIndex].SetActive(false);
            LevelIndex++;
            LevelPrefabs[LevelIndex].SetActive(true);
            Debug.Log("new level  + " + LevelIndex);
            EnableFakeKeyInVendingMachine();
            return;
        }
    }
    /// <summary>
    /// Rotates the side door so the player can have access to the room.
    /// </summary>
    public void RotateSideDoor()
    {
        if(LevelIndex == 2)
        {
            Debug.Log("open door");
            SecuritySecondDoorPrefab.transform.DORotate(new Vector3(0, 90, 0), 3f);
        }
            
        if (LevelIndex == 4)
        {
            MonsterBehaviorRef.RotateModel();
            GlassDoorSecondDoorPrefabTwo.transform.Rotate(new Vector3(0, 91, 0));
            Debug.Log("close door");
        }
    }
    /// <summary>
    /// reopening the side door for a dumb interaction with the monster.
    /// </summary>
    public void ReopenSideDoor()
    {
        GlassDoorSecondDoorPrefabTwo.transform.DORotate(new Vector3(0, -90, 0), 3f);
        Debug.Log("reopen door");
    }

    public void OpenLevelThreeDoor() => LevelThreeDoorPrefab.transform.DORotate(new Vector3(0, 90, 0), 3f);
    /// <summary>
    /// Spawns the player back into pos after finishing a level.
    /// </summary>
    public void RepositionPlayer() => Player.transform.position = PlayerSpawnPoint.transform.position;

    public void EnableFakeKeyInVendingMachine()
    {
        if(LevelIndex == 4)
            KeyInVendingMachine.gameObject.SetActive(true);
    }

    public void RestartLevelGameObjects()
    { 
        LevelThreeDoorPrefab.transform.Rotate(new Vector3(0,0,0));
        SecuritySecondDoorPrefab.transform.Rotate(new Vector3(0, 0, 0));
        ToiletStalls.ForEach(x => x.gameObject.transform.Rotate(new Vector3(0, 0, 0)));
        JumpScareTriggerBox.gameObject.SetActive(true);
    }
    public void TurnOffMonster() => Monster.gameObject.SetActive(false);
    public void TurnOnMonster() => Monster.gameObject.SetActive(true);
    public void RestartGameKeys()
    {
        AllKeysInAllRooms.ToList().ForEach(key => { key.gameObject.SetActive(true); });
        FinalKeyObject.SetActive(false);
    }
}
