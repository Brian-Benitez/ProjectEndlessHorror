using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Transforms")]
    public Transform Player;
    public Transform PlayerSpawnPoint;

    [Header("Level Prefabs")]
    public List<GameObject> LevelPrefabs;
    public GameObject SecondDoorPrefab;

    [Header("Indexs")]
    public int LevelIndex = 0;
    private int _levelCountMax = 4;

    public void ChangeLevelPrefab()
    {
        if (LevelIndex == _levelCountMax)
            return;
        else
        {
            LevelPrefabs[LevelIndex].SetActive(false);
            LevelPrefabs[LevelIndex++].SetActive(true);//Make sure this goes to the next level index
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

    public void RestartLevel()
    {
        RepositionPlayer();
        LevelIndex = 0;
    }
}
