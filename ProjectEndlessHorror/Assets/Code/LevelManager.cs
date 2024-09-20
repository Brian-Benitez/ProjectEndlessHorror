using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
    [Header("Transforms")]
    public Transform Player;
    public Transform PlayerSpawnPoint;

    [Header("LevelPrefabs")]
    public List<GameObject> LevelPrefabs;

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
    /// Spawns the player back into pos after finishing a level.
    /// </summary>
    public void RepositionPlayer()
    {
        Player.transform.position = PlayerSpawnPoint.transform.position;
        Debug.Log("hhhh");
    }
}
