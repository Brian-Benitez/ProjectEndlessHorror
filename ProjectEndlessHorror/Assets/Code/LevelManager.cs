using System.Collections;
using System.Collections.Generic;
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

    [Header("Indexs")]
    public int LevelIndex = 0;
    private int _levelCountMax = 4;

    private void Start() => KeyInVendingMachine.gameObject.SetActive(false);

    public void ChangeLevelPrefab()
    {
        if (LevelIndex == _levelCountMax)
            return;
        else
        {
            LevelPrefabs[LevelIndex].SetActive(false);
            LevelIndex++;
            LevelPrefabs[LevelIndex].SetActive(true);
            Debug.Log("new level  + " + LevelIndex);
            EnableLastKey();
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
            SecuritySecondDoorPrefab.transform.Rotate(new Vector3(0, 90, 0));
        }
            
        if (LevelIndex == 4)
        {
            GlassDoorSecondDoorPrefabTwo.transform.Rotate(new Vector3(0, 91, 0));
            Debug.Log("close door");
        }
    }
    /// <summary>
    /// reopening the side door for a dumb interaction with the monster.
    /// </summary>
    public void ReopenSideDoor()
    {
        GlassDoorSecondDoorPrefabTwo.transform.Rotate(new Vector3(0, -90, 0));
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
        RepositionPlayer();
        LevelIndex = 0;
    }
}
