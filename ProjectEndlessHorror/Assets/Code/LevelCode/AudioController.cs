using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    [Header("Booleans")]
    public bool isPlayingMainAmbience = false;

    [Header("Players Audio")]
    public AudioSource PlayerClickAudio;
    public AudioSource PlayerSettingClickAudio;
    public AudioSource PlayerFootStepAudio;
    //done^
    [Header("Monster Audio")]
    public AudioSource MonsterProximityAudio;
    public AudioSource MonsterEventAudio;
    public AudioSource MonsterKillAudio;

    [Header("Ambience")]
    public AudioSource SecurityAmbienceAudio;
    public AudioSource OfficeAmbienceAudio;
    public AudioSource HallwayAmbienceAudio;
    public AudioSource GrabKeyAudio;
    public AudioSource GrabCashAudio;
    public AudioSource LockedDoorAudio;
    public AudioSource UnlockDoorAudio;
    public AudioSource PressKeyPadAudio;
    public AudioSource StallOpenAudio;
    public AudioSource StallBangingAudio;
    public AudioSource FinalMinuteAudio;
    public AudioSource RestartRoundAudio;

    public AudioSource EasterEggAudio;
    [Header("Scripts")]
    public LevelManager LevelManagerRef;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    //Player footsteps audio (its in player movement loop this)
    public void PlayerFootStepAudioPlay() => PlayerFootStepAudio.Play();
    public void StopPlayingFootStep() => PlayerFootStepAudio.Stop();
    public void PlayOnSettingClickSound() => PlayerSettingClickAudio.Play();
    //Player Audio^------------------------------------------------------------------------------------------------------------------------------------------------
  
    public void OfficeAmbienceSound() => OfficeAmbienceAudio.Play();
    public void SecurityOfficeSound() => SecurityAmbienceAudio.Play();

    public void PlayEasterEggSound() => EasterEggAudio.Play();

    public void MonsterEventSound() => MonsterEventAudio.Play();
    public void RestartRoundSound() => RestartRoundAudio.Play();

    public void JumpScareSoundPlay() => MonsterKillAudio.Play();

    public void MonsterProximitySound()
    {
        MonsterProximityAudio.Stop();
        MonsterProximityAudio.Play();
    }

    public void FinalMintueSound()
    {
        FinalMinuteAudio.Play();
        Debug.Log("play final");
    }

    //Sound Effects-------------------------------------------------------------------------------------------------------------------------------------
    public void PlayUnlockKeyDoorSound() => UnlockDoorAudio.Play();
    public void PlayLockDoorSound() => LockedDoorAudio.Play();
    public void PlayPressKeyPadSound() => PressKeyPadAudio.Play();
    public void PlayPlayerClickingSound() => PlayerClickAudio.Play();

    public void PlayGrabKeysSound() => GrabKeyAudio.Play();
    public void PlayGrabCashSound() => GrabCashAudio.Play();    

    public void PlayStallDoorOpenSound() => StallOpenAudio.Play();
    private void PlayBangingStallDoorSound() => StallBangingAudio.Play();
    private void StopBangingStallDoorSound() => StallBangingAudio.Stop();

    /// <summary>
    /// This checks if its the right level to play this sound, the level index it needs to check is 3.
    /// </summary>
    public void PlayStallBangingOnLvlThree()
    {
        if (LevelManagerRef.LevelIndex == 3)
            PlayBangingStallDoorSound();
        else
            StopBangingStallDoorSound();
    }

    public void SwapTracks()
    {
        StopAllCoroutines();
        StartCoroutine(FadeTrack());
    }
    private IEnumerator FadeTrack()
    {
        float timeToFade = 1.25f;
        float timeElasped = 0;
        if(isPlayingMainAmbience)
        {
            OfficeAmbienceAudio.Play();
            while (timeElasped < timeToFade)
            {
                OfficeAmbienceAudio.volume = Mathf.Lerp(0, 1, timeElasped / timeToFade);
                HallwayAmbienceAudio.volume = Mathf.Lerp(1, 0, timeElasped / timeToFade);
                timeElasped += Time.deltaTime;
                yield return null;
            }
            HallwayAmbienceAudio.Stop();
        }
        else
        {
            HallwayAmbienceAudio.Play();
            while (timeElasped < timeToFade)
            {
                HallwayAmbienceAudio.volume = Mathf.Lerp(0, 1, timeElasped / timeToFade);
                OfficeAmbienceAudio.volume = Mathf.Lerp(1, 0, timeElasped / timeToFade);
                timeElasped += Time.deltaTime;
                yield return null;
            }
            OfficeAmbienceAudio.Stop();
        }

    }
}
