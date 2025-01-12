using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimations : MonoBehaviour
{
    [Header("Animator")]
    public Animator MonsterAnimator;

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
