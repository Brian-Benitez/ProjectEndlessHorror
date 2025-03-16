using DG.Tweening;
using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainDoor : MonoBehaviour, IInteractable
{
    [Header("Scripts")]
    public PlayerInventory PlayerInventoryRef;
    public LevelManager LevelManagerRef;
    public CameraFade CameraFadeRef;
    public SettingsController SettingsControllerRef;
    public AudioController AudioControllerRef;

    public void Interact()
    {
        if (LevelManagerRef.LevelIndex == 5)//Ending scene
        {
            CameraFadeRef.FadeToBlack();//Fade to black, have dialoge play, then kill the game.
            Delay(15f, () =>
            {
                Debug.Log("killing game");
                Application.Quit();
            });
        }
        else if (PlayerInventoryRef.DoesPlayerHaveKey() || LevelManagerRef.LevelIndex == 0)
        {
            AudioControllerRef.PlayUnlockKeyDoorSound();
            SettingsControllerRef.PausePlayerInput();
            CameraFadeRef.FadeToBlack();
            Delay(1f, () =>
            {
                GameMain.instance.AdvanceToNextLevel();
                SettingsControllerRef.UnPausePlayersInput();
            });
        }
        else
            AudioControllerRef.PlayLockDoorSound();
    }

    private static void Delay(float time, System.Action _callBack)
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(time).AppendCallback(() => _callBack());
    }
}
