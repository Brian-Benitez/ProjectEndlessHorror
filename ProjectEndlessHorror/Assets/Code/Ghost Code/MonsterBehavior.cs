using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterBehavior : MonoBehaviour
{
    [Header("Monsters Info")]
    [SerializeField] private float _speed = 1.5f;//Monsters speed to points or to the player
    [SerializeField] private int _spawnPointIndex = 0;
    [SerializeField] public float WaitSpeedForMonster = 0.5f;
    [SerializeField] public int MonsterTravelEndPoints = 0;
    
    [Header("Positions")]
    public Transform JumpScarePos;
    public Transform PlayersPos;
    [Header("Booleans")]
    public bool GotJumpScared = false;

    [Header("Lists of spawn points")]
    public List<GameObject> SpawnPointPerLevel;

    [Header("List of end points")]
    public List <GameObject> EndPointsOfMovement;

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

        if (_spawnPointIndex == SpawnPointPerLevel.Count)
            yield break;
        else
            while (Vector3.Distance(this.transform.position, EndPointsOfMovement[MonsterTravelEndPoints].transform.position) > 0.05f)//start this and dont end until they are less than 0.05 meters away
            {
                this.transform.position = Vector3.MoveTowards(transform.position, EndPointsOfMovement[MonsterTravelEndPoints].transform.position, _speed * Time.deltaTime);
                yield return null;
            }

        if(Vector3.Distance(this.transform.position, EndPointsOfMovement[MonsterTravelEndPoints].transform.position) <= 0.05f)//if it gets to its point, turn off monster.
        {
            if(LevelManagerRef.LevelIndex == 4)
                LevelManagerRef.ReopenSideDoor();

            DisableObject();
            MonsterTravelEndPoints++;
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

        MonsterAnimationsRef.SetAnimationForMonster();

        if(LevelManagerRef.LevelIndex == 4)
        {
            if(StartChaseSequnceRef.IsChasingPlayer == false)
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

    public void PlayInstanceJumpScare()
    {
        GotJumpScared = true;
        CameraControllerRef.InstanceJumpScareCamOn();
        Delay(2f, () =>
        {
            CameraFadeRef.FadeToBlack();

            Delay(0.5f, () =>
            {
                GameMain.instance.PlayLostViaTimeDelegate();
                Debug.Log("THIS PLAYS");
            });
        });

    }
    /// <summary>
    /// Starts the jumpscare then resets level and player
    /// </summary>
    public void TimedMonsterJumpScare()
    {
        GotJumpScared = true;
        int randomWaitTime = Random.Range(1, 3);
        Debug.Log("whats the wait time " + randomWaitTime);
        CameraFadeRef.FadeToBlack();
        CameraControllerRef.TurnOnTimedJumpScareCam();
        GotScaredBool();

        //Randomly wait for jumpscare
        Delay(randomWaitTime, () =>
        {
            CameraFadeRef.FadeOffOfBlack();
            MonsterAnimationsRef.StartJumpScareMonsterAnimation();
            Debug.Log("jumpscare");

            Delay(2f, () =>
            {
                CameraFadeRef.FadeToBlack();

                Delay(0.5f, () =>
                {
                    GameMain.instance.PlayLostViaTimeDelegate();
                });
            });
        });
    }

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
            Debug.Log("how much does it get caled");
        }
    }

    public void UnRotateModel()
    {
        if (LevelManagerRef.LevelIndex == 4)
        {
            this.transform.Rotate(0, 0, 0);
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
