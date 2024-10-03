using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    public GameObject MonsterPrefab;

    [Header("Transforms aka Spawnpoints")]
    public List<Transform> LevelTwoSpawnList;

    [Header("Players pos")]
    public Transform JumpScarePos;


    private bool MonsterIsSeen = false;//somehow need to make this true
    public void LevelOneMonsterBehavior()
    {
        MonsterPrefab.transform.position = LevelTwoSpawnList[0].transform.position;//First spawn the monster in the correct pos.

        if(MonsterIsSeen)
        {
            //Somehow when seen, disapear from the scene
            //randomly pick a spot to spawn in watching the player.
            int spawnPoint = Random.Range(0, LevelTwoSpawnList.Count);
            MonsterPrefab.transform.position = LevelTwoSpawnList[spawnPoint].transform.position;
            //need to somehow check if the player sees the monster then do something
        }
    }

    public void MonstersJumpScarePosition()
    {
        MonsterPrefab.transform.position = JumpScarePos.transform.position;
        //Play jump scare animation here.
    }
}
