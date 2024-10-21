using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class MonsterBehavior : MonoBehaviour
{
    [Header("Monsters Info")]
    [SerializeField] private float _speed = 1.5f;//Monsters speed to points or to the player
    [SerializeField] private int _spawnPointIndex = 0;

    [Header("Positions")]
    public Transform JumpScarePos;
    public GameObject EndPoint;

    [Header("Lists of spawn points")]
    public List<GameObject> SpawnPointPerLevel;

    [Header("List of end points")]
    public List <GameObject> EndPointsOfMovement;

    [Header("Scripts")]
    public LevelManager LevelManagerRef;

    /// <summary>
    /// Moves the monster to the point it needs to be.
    /// </summary>
    IEnumerator MoveMonsterToPoint()
    {
        if (_spawnPointIndex == SpawnPointPerLevel.Count)
            yield break;
        else
            while (Vector3.Distance(transform.position, EndPoint.transform.position) > 0.05f)//start this and dont end until they are less than 0.05 meters away
            {
                transform.position = Vector3.MoveTowards(transform.position, EndPoint.transform.position, _speed * Time.deltaTime);
                Debug.Log(Vector3.Distance(transform.position, EndPoint.transform.position) + " this is the distance");
                yield return null;
            }

        if(Vector3.Distance(transform.position, EndPoint.transform.position) <= 0.05f)//if it gets to its point, turn off the monsters game object.
        {
            transform.gameObject.SetActive(false);
            _spawnPointIndex++;
        }
    }

    public void StartMonsterMovement () => StartCoroutine(MoveMonsterToPoint());
    /// <summary>
    /// Total of 4 levels 3 out of the 4 levels the monster will spawn in.
    /// </summary>
    public void SpawnMonsterInArea()
    {
        transform.gameObject.SetActive(true);

        if(LevelManagerRef.LevelIndex == 0)
            return;
        else
        {
            this.transform.position = SpawnPointPerLevel[0].transform.position;
            Debug.Log("what " + LevelManagerRef.LevelIndex);
        }
            
    }

    public void MonstersJumpScarePosition()
    {
        this.transform.position = JumpScarePos.transform.position;
        //Play jump scare animation here.
    }
    /*
    private static void Delay(float time, System.Action _callBack)
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(time).AppendCallback(() => _callBack());
    }
    */

    public void RestartMonstersBehavior()
    {
        _spawnPointIndex = 0;
        transform.gameObject.SetActive(true);
    }
}
