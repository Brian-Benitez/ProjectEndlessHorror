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
    public GameObject GlassDoorSecondDoorPrefab;

    [Header("Indexs")]
    public int LevelIndex = 0;
    private int _levelCountMax = 5;

    public void ChangeLevelPrefab()
    {
        if (LevelIndex == _levelCountMax)
            return;
        else
        {
            LevelPrefabs[LevelIndex].SetActive(false);
            LevelIndex++;//this needs to be de
            LevelPrefabs[LevelIndex].SetActive(true);
            Debug.Log("new level  + " + LevelIndex);
        }
    }
    /// <summary>
    /// Rotates the side door so the player can have access to the room.
    /// </summary>
    public void RotateSideDoor()
    {
        if(LevelIndex == 2)
            SecuritySecondDoorPrefab.transform.Rotate(new Vector3(0, 90, 0));
        if (LevelIndex == 4)
            GlassDoorSecondDoorPrefab.transform.Rotate(new Vector3(0, 0, 0));// need to open this door now lmao

        Debug.Log("open door");
    }
    /// <summary>
    /// Spawns the player back into pos after finishing a level.
    /// </summary>
    public void RepositionPlayer() => Player.transform.position = PlayerSpawnPoint.transform.position;

    public void RestartLevel()
    {
        RepositionPlayer();
        LevelIndex = 0;
    }
}
