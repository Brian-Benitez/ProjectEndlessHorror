using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimations : MonoBehaviour
{
    [Header("Animator")]
    public Animator MonsterAnimator;
    public Animator JumpScareMonsterAnimator;

    [Header("Scripts")]
    public LevelManager LevelManagerRef;

    public void SetAnimationForMonster()
    {
        Debug.Log("animation update");
        SetAllBoolsToFalse();
        Debug.Log("check index " + LevelManagerRef.LevelIndex);
        switch (LevelManagerRef.LevelIndex)
        {
            case 1://Walking encounter
                MonsterAnimator.SetBool("IsWalking", true);
                break;
            case 2:
                MonsterAnimator.SetBool("IsIdle", true);
                break;
            case 3:
                MonsterAnimator.SetBool("IsKneeling", true);
                break;
            case 4:
                MonsterAnimator.SetBool("IsRunning", true);
                break;

            default:
                Debug.Log("This is default do nothing");
                break;
        }
    }

    public void StartJumpScareMonsterAnimation()
    {
        JumpScareMonsterAnimator.gameObject.SetActive(true);
        ///JumpScareMonsterAnimator.Play("JumpScare");
    }

    public void StopJumpScareAnimation() => JumpScareMonsterAnimator.gameObject.SetActive(false); 
    /// <summary>
    /// Set all bools from the animator to false.
    /// </summary>
    private void SetAllBoolsToFalse()
    {
        MonsterAnimator.SetBool("IsWalking", false);
        MonsterAnimator.SetBool("IsKneeling", false);
        MonsterAnimator.SetBool("IsIdle", false);
        MonsterAnimator.SetBool("IsRunning", false);
    }
}
