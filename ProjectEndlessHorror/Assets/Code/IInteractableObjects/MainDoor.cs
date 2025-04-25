using DG.Tweening;
//using Steamworks;
using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainDoor : MonoBehaviour, IInteractable
{
    [Header("End game parameteres")]
    public float EndingDialogueTimer = 45f;

    [Header("Scripts")]
    public PlayerInventory PlayerInventoryRef;
    public LevelManager LevelManagerRef;
    public CameraFade CameraFadeRef;
    public SettingsController SettingsControllerRef;
    public EasterEggController EasterEggControllerRef;
    public StartChaseSequnce StartChaseSequnceRef;
    public MonsterBehavior MonsterBehaviorRef;
    public GameTimer GameTimerRef;
    public void Interact()
    {

        //if(SteamManager.Initialized)
        //{
            if (LevelManagerRef.LevelIndex == 4)//Ending scene
            {
                Debug.Log("end ofgame");
                AudioController.instance.StopPlayingAllVO();
                AudioController.instance.StopPlayingFinalMintue();
                AudioController.instance.StopAllAmbienceAudio();
            LevelManagerRef.TurnOffMonster();
                GameTimerRef.PauseTheGameTimer();
                SettingsControllerRef.PausePlayerInput();
                CameraFadeRef.FadeToBlack();//Fade to black, have dialoge play, then kill the game.
                GameMain.instance.GameIsFinishedSetTrue();

            if (EasterEggControllerRef.IsEasterEggEnabled)
            {

                //Steamworks.SteamUserStats.GetAchievement("Achievement_Two", out bool achivementCompleted);
                //if (!achivementCompleted)
                //{
                //SteamUserStats.SetAchievement("Achievement_Two");
                //SteamUserStats.StoreStats();
                //}

                Debug.Log("play this audio");
                AudioController.instance.PlayEasterEggEndingSound();
            }
            else
                AudioController.instance.PlayNoEasterEggEndingSound();

            Delay(EndingDialogueTimer, () =>// it was 15 sec now its this <---
                {
                    SettingsControllerRef.UnPausePlayersInput();
                    if (!EasterEggControllerRef.IsEasterEggEnabled)
                    {
                        LevelManagerRef.TurnOnMonster();
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
                AudioController.instance.StopPlayingAllVO();
                AudioController.instance.StopPlayingFinalMintue();
                AudioController.instance.StopAllAmbienceAudio();
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
