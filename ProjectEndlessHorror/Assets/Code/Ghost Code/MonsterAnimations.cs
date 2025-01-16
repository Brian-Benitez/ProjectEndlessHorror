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
        SetAllBoolsToFalse();

        switch (LevelManagerRef.LevelIndex)
        {
            case 1://Walking encounter
                MonsterAnimator.SetBool("IsWalking", true);
                break;

            default:
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
