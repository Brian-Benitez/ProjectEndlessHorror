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
    
    [Header("Vo's")]
    public List<AudioSource> VoiceOvers;
    public AudioSource EasterEggEndingAudio;
    public AudioSource NoEasterEggEndingAudio;

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
    public AudioSource EightThreeFiveAudio;

    
    [Header("Scripts")]
    public LevelManager LevelManagerRef;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void PlayOnSettingClickSound() => PlayerSettingClickAudio.Play();
    //Player Audio^------------------------------------------------------------------------------------------------------------------------------------------------
  
    public void OfficeAmbienceSound() => OfficeAmbienceAudio.Play();
    public void SecurityOfficeSound() => SecurityAmbienceAudio.Play();

    public void PlayEasterEggEndingSound() => EasterEggEndingAudio.Play();
    public void PlayNoEasterEggEndingSound() => NoEasterEggEndingAudio.Play();

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
    //VO's--------------------------------------------------------------------------------------------------------------------------------------------->
    public void PlayingLevelVO()
    {
        VoiceOvers.ForEach(x => x.Stop());  
        VoiceOvers[LevelManagerRef.LevelIndex].Play();
        Debug.Log("Playing voice over for this level");
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

    private void PlayDoorCodeAudio() => EightThreeFiveAudio.Play();
    private void StopDoorCodeAudio() => EightThreeFiveAudio.Stop();

    /// <summary>
    /// Adjust all audio in the scene.
    /// </summary>
    /// <param name="volumevalue"></param>
    public void AdjustAllVolume(float volumevalue)
    {
        StallBangingAudio.volume = volumevalue;
        StallBangingAudio.volume = volumevalue;
        StallBangingAudio.volume = volumevalue;
        GrabCashAudio.volume = volumevalue;
        GrabCashAudio.volume = volumevalue;
        PressKeyPadAudio.volume = volumevalue;
        PlayerClickAudio.volume = volumevalue;
        LockedDoorAudio.volume = volumevalue;
        UnlockDoorAudio.volume = volumevalue;
        FinalMinuteAudio.volume = volumevalue;
        MonsterProximityAudio.volume = volumevalue;
        MonsterKillAudio.volume = volumevalue;
        RestartRoundAudio.volume = volumevalue;
        MonsterEventAudio.volume = volumevalue;
        EightThreeFiveAudio.volume = volumevalue;
        //EasterEggAudio.volume = volumevalue;
        SecurityAmbienceAudio.volume = volumevalue;
        OfficeAmbienceAudio.volume = volumevalue; 
        PlayerSettingClickAudio.volume = volumevalue;
        //PlayerFootStepAudio.volume = volumevalue;
        VoiceOvers.ForEach(x => x.volume = volumevalue);
    }

    /// <summary>
    /// This checks if its the right level to play these sounds, the level index it needs to check is 3.
    /// </summary>
    public void PlayCertainSoundsOnLvlThree()
    {
        if (LevelManagerRef.LevelIndex == 3)
        {
            PlayBangingStallDoorSound();
            PlayDoorCodeAudio();
        }  
        else
        {
            StopBangingStallDoorSound();
            StopDoorCodeAudio();
        }
            
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
