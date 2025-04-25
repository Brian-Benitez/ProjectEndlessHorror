using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterBehavior : MonoBehaviour
{
    [Header("Monsters Info")]
    [SerializeField] private float _speedToPoints = 1.5f;//Monsters speed to points
    [SerializeField] private int _spawnPointIndex = 0;
    [SerializeField] public float WaitSpeedForMonster = 0.5f;
    [SerializeField] public int MonsterTravelEndPoints = 0;
    public float DurationOfJumpScare = 0.5f;
    public float DurationOfWaitTime = 2f;
    
    [Header("Positions")]
    public Transform JumpScarePos;
    public Transform PlayersPos;
    [Header("Booleans")]
    public bool GotJumpScared = false;

    [Header("Lists of spawn points")]
    public List<GameObject> SpawnPointPerLevel;

    [Header("List of end points")]
    public List <GameObject> EndPointsOfMovement;

    public GameObject TriggerMonsterMovementRef;

    [Header("Scripts")]
    public LevelManager LevelManagerRef;
    public CameraController CameraControllerRef;
    public CameraFade CameraFadeRef;
    public MonsterAnimations MonsterAnimationsRef;
    public StartChaseSequnce StartChaseSequnceRef;
    public AudioController AudioControllerRef;
    

    public void AddAIndex()=> _spawnPointIndex++;

    /// <summary>
    /// Moves the monster to the point it needs to be.
    /// </summary>
    IEnumerator MoveMonsterToPoint()//NOTE, IF U DO THIS BEFORE THE COROTINE FINISHES THE LEVEL, IT WILL DO IT AGAIN.
    {
        AudioControllerRef.MonsterEventSound();

        if (LevelManagerRef.LevelIndex == 4)
        {
            MonsterTravelEndPoints = 1;
           
        }
        else
            MonsterTravelEndPoints = 0;

        if (_spawnPointIndex == SpawnPointPerLevel.Count)
            yield break;
        else
            while (Vector3.Distance(this.transform.position, EndPointsOfMovement[MonsterTravelEndPoints].transform.position) > 0.05f)//start this and dont end until they are less than 0.05 meters away
            {
                this.transform.position = Vector3.MoveTowards(transform.position, EndPointsOfMovement[MonsterTravelEndPoints].transform.position, _speedToPoints * Time.deltaTime);
                yield return null;
            }

        if(Vector3.Distance(this.transform.position, EndPointsOfMovement[MonsterTravelEndPoints].transform.position) <= 0.05f)//if it gets to its point, turn off monster.
        {
            if(LevelManagerRef.LevelIndex == 4)
                LevelManagerRef.ReopenSideDoor();

            DisableObject();
        }
    }

    public void StartMonsterMovement()
    {
        if(LevelManagerRef.LevelIndex == 4)
        {
            UnRotateModel();
            RotateModel();
        }

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
        UnRotateModel();
        AudioControllerRef.MonsterProximitySound();
        MonsterAnimationsRef.SetAnimationForMonster();

        if(LevelManagerRef.LevelIndex == 4)
        {
           
            if (StartChaseSequnceRef.IsChasingPlayer == false)
            {
                DisableObject();
                Debug.Log("lpoppk");
            }
        }

        if (StartChaseSequnceRef.IsChasingPlayer)
        {
            Debug.Log("chase player");
            EnableObject();
            UnRotateModel();
            this.transform.position = SpawnPointPerLevel[5].transform.position;
        }
        else
            this.transform.position = SpawnPointPerLevel[_spawnPointIndex].transform.position;
        Debug.Log("what is the spawnpoint index " + _spawnPointIndex);
    }

    public void PlayJumpScare()
    {
        GotJumpScared = true;
        CameraControllerRef.InstanceJumpScareCamOn();//this too
        MonsterAnimationsRef.StartJumpScareMonsterAnimation();//I should subscribe this to gamemain.....
        Delay(DurationOfJumpScare, () =>
        {
            CameraFadeRef.FadeToBlack();
            
            Delay(DurationOfWaitTime, () =>
            {
                GameMain.instance.PlayerLostDelegate();
                Debug.Log("THIS PLAYS");
            });
        });

    }

    public void RestartJumpScareTrigger() => TriggerMonsterMovementRef.gameObject.SetActive(true);

    public void RestartMonstersBehavior()
    {
        _spawnPointIndex = 0;
        EnableObject();
    }
    //HELPER functions +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    public void RotateModel()
    {
        if (LevelManagerRef.LevelIndex == 4)
        {
            this.transform.Rotate(0, 90, 0);
            Debug.Log("hi 1");
        }
    }

    public void UnRotateModel()
    {
        if (LevelManagerRef.LevelIndex == 4)
        {
            this.transform.Rotate(0, 0, 0);
            Debug.Log("hi 2");
        }
    }
    
    public void FixIt()
    {
        if(LevelManagerRef.LevelIndex == 4)
        {
            EnableObject();
            this.transform.Rotate(0, 0, 0);
            DisableObject();
        }
    }

    public void GotScaredBool() => GotJumpScared = true;
    
    public void RestartJumpScareBool() => GotJumpScared = false;

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
