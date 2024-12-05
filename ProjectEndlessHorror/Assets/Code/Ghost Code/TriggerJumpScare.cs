using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJumpScare : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameMain.instance.PlayingJumpScareDelegate();
        }
    }

    private static void Delay(float time, System.Action _callBack)
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(time).AppendCallback(() => _callBack());
    }
}
