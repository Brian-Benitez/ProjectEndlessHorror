using DG.Tweening;
using Steamworks;
using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainDoor : MonoBehaviour, IInteractable
{
    public float EndingDialogueTimer = 45f;
    [Header("Scripts")]
    public PlayerInventory PlayerInventoryRef;
    public LevelManager LevelManagerRef;
    public CameraFade CameraFadeRef;
    public SettingsController SettingsControllerRef;
    public EasterEggController EasterEggControllerRef;
    public void Interact()
    {
        //if(SteamManager.Initialized)
        //{
            if (LevelManagerRef.LevelIndex == 5)//Ending scene
            {
                CameraFadeRef.FadeToBlack();//Fade to black, have dialoge play, then kill the game.

                if (EasterEggControllerRef.IsEasterEggEnabled)
                {
                    /*
                    Steamworks.SteamUserStats.GetAchievement("Achievement_Two", out bool achivementCompleted);
                    if (!achivementCompleted)
                    {
                        SteamUserStats.SetAchievement("Achievement_Two");
                        SteamUserStats.StoreStats();
                    }
                    */
                    Debug.Log("play this audio");
                }
                else
                    Debug.Log("play this audio then");

                Delay(EndingDialogueTimer, () =>// it was 15 sec now its this <---
                {
                    if (!EasterEggControllerRef.IsEasterEggEnabled)
                    {
                        GameMain.instance.PlayingRestartGameLogicDelegate();
                        /*
                        Steamworks.SteamUserStats.GetAchievement("Achievement_One", out bool achivementCompleted);
                        if(!achivementCompleted)
                        {
                            SteamUserStats.SetAchievement("Achievement_One");
                            SteamUserStats.StoreStats();
                        }
                        */
                    }
                    else
                    {
                        Debug.Log("killing game");
                        Application.Quit();
                    }
                });
            }
            else if (PlayerInventoryRef.DoesPlayerHaveKey() || LevelManagerRef.LevelIndex == 0)
            {
                AudioController.instance.PlayUnlockKeyDoorSound();
                SettingsControllerRef.PausePlayerInput();
                CameraFadeRef.FadeToBlack();
                Delay(1f, () =>
                {
                    GameMain.instance.AdvanceToNextLevel();
                    SettingsControllerRef.UnPausePlayersInput();
                });
            }
            else
                AudioController.instance.PlayLockDoorSound();
        //}
    }

    private static void Delay(float time, System.Action _callBack)
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(time).AppendCallback(() => _callBack());
    }
}
