using DG.Tweening;
using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainDoor : MonoBehaviour, IInteractable
{
    public PlayerInventory PlayerInventoryRef;
    public LevelManager LevelManagerRef;
    public CameraFade CameraFadeRef;
    public SettingsController SettingsControllerRef;    

    public void Interact()
    {
        if (PlayerInventoryRef.DoesPlayerHaveKey() || LevelManagerRef.LevelIndex == 0)
        {
            SettingsControllerRef.PausePlayerInput();
            CameraFadeRef.FadeToBlack();
            Delay(1f, () =>
            {
                GameMain.instance.AdvanceToNextLevel();
                SettingsControllerRef.UnPausePlayersInput();
            });
        }
        else
            Debug.Log("does not have the key");
    }

    private static void Delay(float time, System.Action _callBack)
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(time).AppendCallback(() => _callBack());
    }
}
