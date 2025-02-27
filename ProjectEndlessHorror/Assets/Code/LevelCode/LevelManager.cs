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

    [Header("Levels")]
    public List<GameObject> LevelPrefabs;
    public GameObject SecuritySecondDoorPrefab;
    public GameObject GlassDoorSecondDoorPrefabTwo;
    public GameObject KeyInVendingMachine;
    public List<GameObject> AllKeysInAllRooms;

    [Header("Indexs")]
    public int LevelIndex = 0;
    private int _levelCountMax = 5;

    [Header("Scripts")]
    public MonsterBehavior MonsterBehaviorRef;
    public GameTimer GameTimerRef;

    private void Start() => KeyInVendingMachine.gameObject.SetActive(false);

    public void ChangeLevelPrefab()
    {
        if (LevelIndex == _levelCountMax || MonsterBehaviorRef.GotJumpScared)
            return;
        else
        {
            LevelPrefabs[LevelIndex].SetActive(false);
            LevelIndex++;
            LevelPrefabs[LevelIndex].SetActive(true);
            Debug.Log("new level  + " + LevelIndex);
            EnableLastKey();
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
    /// <summary>
    /// Spawns the player back into pos after finishing a level.
    /// </summary>
    public void RepositionPlayer() => Player.transform.position = PlayerSpawnPoint.transform.position;

    public void EnableLastKey()
    {
        if(LevelIndex == 4)
            KeyInVendingMachine.gameObject.SetActive(true);
    }

    public void RestartLevel()
    {
        if(GameTimerRef.TimerIsRunning == false || MonsterBehaviorRef.GotJumpScared)
        {
            Debug.Log("restart level");
            AllKeysInAllRooms.ToList().ForEach(key => { key.gameObject.SetActive(true); });
        }
    }

    public void RestartGame()
    {
        LevelIndex = 0;
    }
}
