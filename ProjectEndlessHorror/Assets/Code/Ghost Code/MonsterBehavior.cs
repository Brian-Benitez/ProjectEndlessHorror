using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    [Header("Monsters Info")]
    [SerializeField] private float _speed = 1.5f;//Monsters speed to points or to the player
    [SerializeField] private int _spawnPointIndex = 0;
    [SerializeField] public float WaitSpeedForMonster = 0.5f;

    [Header("Positions")]
    public Transform JumpScarePos;

    [Header("Lists of spawn points")]
    public List<GameObject> SpawnPointPerLevel;

    [Header("List of end points")]
    public List <GameObject> EndPointsOfMovement;

    [Header("Scripts")]
    public LevelManager LevelManagerRef;
    public CameraController CameraControllerRef;


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            MonstersJumpScarePosition();
        }
    }

    /// <summary>
    /// Moves the monster to the point it needs to be.
    /// </summary>
    IEnumerator MoveMonsterToPoint()//NOTE, IF U DO THIS BEFORE THE COROTINE FINISHES THE LEVEL, IT WILL DO IT AGAIN.
    {
        if (_spawnPointIndex == SpawnPointPerLevel.Count)
            yield break;
        else
            while (Vector3.Distance(transform.position, EndPointsOfMovement[_spawnPointIndex].transform.position) > 0.05f)//start this and dont end until they are less than 0.05 meters away
            {
                transform.position = Vector3.MoveTowards(transform.position, EndPointsOfMovement[_spawnPointIndex].transform.position, _speed * Time.deltaTime);
                yield return null;
            }

        if(Vector3.Distance(transform.position, EndPointsOfMovement[_spawnPointIndex].transform.position) <= 0.05f)//if it gets to its point, turn off monster.
        {
            if(LevelManagerRef.LevelIndex == 4)
                LevelManagerRef.ReopenSideDoor();

            DisableObject();
            _spawnPointIndex++;
        }
    }

    public void StartMonsterMovement()
    {
        Delay(WaitSpeedForMonster, () =>
        {
            StartCoroutine(MoveMonsterToPoint());
            Debug.Log("delay call here");
        });
    } 

    /// <summary>
    /// Total of 5 levels, 4 out of the 5 levels the monster will spawn in.
    /// </summary>
    public void SpawnMonsterInArea()
    {
        EnableObject();

        if(LevelManagerRef.LevelIndex == 4)
            DisableObject();
        Debug.Log("what the level index before " + LevelManagerRef.LevelIndex);
        this.transform.position = SpawnPointPerLevel[LevelManagerRef.LevelIndex].transform.position;
        Debug.Log("what the level index " + LevelManagerRef.LevelIndex);
    }

    public void MonstersJumpScarePosition()
    {
        this.transform.position = JumpScarePos.transform.position;
        CameraControllerRef.TurnOnJumpScareCam();
        Debug.Log("jumpscare");
        //Play jump scare animation here.
    }

    public void RestartMonstersBehavior()
    {
        _spawnPointIndex = 0;
        EnableObject();
    }
    //HELPER functions +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    /// <summary>
    /// Enables this object.
    /// </summary>
    public void EnableObject() => transform.gameObject.SetActive(true);
    /// <summary>
    /// Disables this object.
    /// </summary>
    public void DisableObject() => transform.gameObject.SetActive(false);

    
   private static void Delay(float time, System.Action _callBack)
   {
       Sequence seq = DOTween.Sequence();

       seq.AppendInterval(time).AppendCallback(() => _callBack());
   }
  
}
