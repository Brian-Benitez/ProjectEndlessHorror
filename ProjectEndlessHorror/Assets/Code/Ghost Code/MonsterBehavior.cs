using DG.Tweening;
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
    private void Update()
    {
        //MoveMonsterToPoint();
    }
    /// <summary>
    /// Moves the monster to the point it needs to be.
    /// </summary>
    public IEnumerator MoveMonsterToPoint()
    {
        while(Vector3.Distance(transform.position, EndPoint.transform.position) < 0.05f)//start this and dont end until they are less than 0.05 meters away
        {
            transform.position = Vector3.MoveTowards(transform.position, EndPoint.transform.position, _speed * Time.deltaTime);
            yield return null;
        }
        Debug.Log("done");
        this.transform.gameObject.SetActive(false);
    }
    /// <summary>
    /// Total of 4 levels 3 out of the 4 levels the monster will spawn in.
    /// </summary>
    public void SpawnMonsterInArea()
    {
        Debug.Log("what is it  " + LevelManagerRef.LevelIndex);
        
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

    private static void Delay(float time, System.Action _callBack)
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(time).AppendCallback(() => _callBack());
    }
}
