using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
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

    //Player footsteps audio (its in player movement loop this)
    public void PlayerFootStepAudioPlay() => PlayerFootStepAudio.Play();
    public void StopPlayingFootStep() => PlayerFootStepAudio.Stop();

    //Player Settings audio (In settings controller play this once only)
    public void PlayOnSettingClickSound() => PlayerSettingClickAudio.Play();
  
    public void SecurityOfficeSound() => OfficeAmbienceAudio.Play();

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
    public void UnlockKeyDoorSound() => UnlockDoorAudio.Play();
    public void PressKeyPadSound() => PressKeyPadAudio.Play();
    public void PlayPlayerClickingSound() => PlayerClickAudio.Play();
}
