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
        Debug.Log("check index " + LevelManagerRef.LevelIndex);
        switch (LevelManagerRef.LevelIndex)
        {
            case 1:
                MonsterAnimator.SetTrigger("TRWalking");
                break;
            case 2:
                MonsterAnimator.SetTrigger("TRIdle");
                Debug.Log("aehh");
                break;
            case 3:
                MonsterAnimator.SetTrigger("TRKneeling");
                break;
            case 4:
                MonsterAnimator.SetTrigger("TRunning");
                break;
        }
        Debug.Log("check index again" + LevelManagerRef.LevelIndex);
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
}
