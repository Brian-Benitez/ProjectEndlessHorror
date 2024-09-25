using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
    [Header("Transforms")]
    public Transform Player;
    public Transform PlayerSpawnPoint;

    [Header("Level Prefabs")]
    public List<GameObject> LevelPrefabs;
    public GameObject SecondDoorPrefab;

    private int _levelIndex = 0;
    private int _levelCount = 4;

    public void ChangeLevelPrefab()
    {
        if (_levelIndex == _levelCount)
            return;
        else
        {
            LevelPrefabs[_levelIndex].SetActive(false);
            LevelPrefabs[_levelIndex++].SetActive(true);//Make sure this goes to the next level index
        }
    }
    /// <summary>
    /// Rotates the side door so the player can have access to the room.
    /// </summary>
    public void RotateSideDoor() => SecondDoorPrefab.transform.Rotate(new Vector3(0, 90, 0));
    /// <summary>
    /// Spawns the player back into pos after finishing a level.
    /// </summary>
    public void RepositionPlayer()
    {
        Player.transform.position = PlayerSpawnPoint.transform.position;
        Debug.Log("hhhh");
    }
}
