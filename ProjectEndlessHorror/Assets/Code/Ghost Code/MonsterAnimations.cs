using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimations : MonoBehaviour
{
    [Header("Animator")]
    public Animator MonsterAnimator;

    [Header("GameObject")]
    public GameObject MonsterPrefab;

    [Header("Scripts")]
    public LevelManager LevelManagerRef;

    private void Start()
    {
        StopJumpScareAnimation();
    }

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
                MonsterAnimator.SetTrigger("TRRunning");
                break;
        }
        Debug.Log("check index again" + LevelManagerRef.LevelIndex);
    }

    public void StartJumpScareMonsterAnimation() => MonsterPrefab.gameObject.SetActive(true);

    public void StopJumpScareAnimation() => MonsterPrefab.gameObject.SetActive(false);
}
