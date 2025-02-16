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
        ResetsAnimations();
        Debug.Log("animation update");
        Debug.Log("check index " + LevelManagerRef.LevelIndex);
        switch (LevelManagerRef.LevelIndex)
        {
            case 1://Walking encounter
                MonsterAnimator.SetTrigger("SetWalkingTrigger");
                Debug.Log("SEE THIS");
                break;
            case 2:
                MonsterAnimator.SetTrigger("SetIdleTrigger");
                Debug.Log("aehh");
                break;
            case 3:
                MonsterAnimator.SetTrigger("SetKneelingTrigger");
                break;
            case 4:
                MonsterAnimator.SetTrigger("SetRunningTrigger");
                break;
        }
    }
    private void ResetsAnimations()
    {
        MonsterAnimator.ResetTrigger("SetWalkingTrigger");
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
