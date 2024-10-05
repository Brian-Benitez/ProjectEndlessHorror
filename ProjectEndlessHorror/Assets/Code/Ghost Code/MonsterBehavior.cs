using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    [Header("Monsters Info")]
    [SerializeField] private float _speed = 1.5f;//Monsters speed to points or to the player

    [Header("Positions")]
    public Transform JumpScarePos;
    public GameObject EndPoint;

    [Header("Spawn points")]
    public List<GameObject> SpawnPointPerLevel;

    [Header("Scripts")]
    public LevelManager LevelManagerRef;
    private void Start()
    {
        SpawnPointPerLevel = new List<GameObject>();
    }

    private void Update()
    {
        //MoveMonsterToPoint();
    }

    public void MoveMonsterToPoint()
    {
        if(this.transform.position == EndPoint.transform.position)
        {
            this.transform.gameObject.SetActive(false);
            return;
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, EndPoint.transform.position, _speed * Time.deltaTime);
    }
    /// <summary>
    /// Total of 4 levels 3 out of the 4 levels the monster will spawn in.
    /// </summary>
    public void SpawnMonsterInArea()
    {
        if(LevelManagerRef.LevelIndex == 0)
            return;
        else
            this.transform.position = SpawnPointPerLevel[LevelManagerRef.LevelIndex].transform.position;
    }

    public void MonstersJumpScarePosition()
    {
        this.transform.position = JumpScarePos.transform.position;
        //Play jump scare animation here.
    }
}
