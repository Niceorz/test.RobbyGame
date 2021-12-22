﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    static AudioManager current;

    [Header("环境声音")]
    public AudioClip ambientClip;
    public AudioClip musicClip;
    [Header("Robbie音效")]
    public AudioClip[] walkStepClips;
    public AudioClip[] crouchStepClips;
    public AudioClip jumpClip;
    public AudioClip jumpVoiceClip;
    public AudioClip deathClip;
    public AudioClip deathVoiceClip;
    public AudioClip orbVoiceClip;
    [Header("FX音效")]
    public AudioClip deathFXClip;
    public AudioClip orbFXClip;
    public AudioClip doorFXClip;
    public AudioClip startLevelClip;
    public AudioClip winClip;

    AudioSource ambientSource;
    AudioSource musicSource;
    AudioSource fxSource;
    AudioSource playerSource;
    AudioSource voiceSource;

    public AudioMixerGroup ambientGroup, musicGroup, FXGroup, playerGroup, voiceGroup;

    public AudioMixer masterGroup;

    private void Awake()
    {
        if (current != null)
        {
            Destroy(gameObject);
            return;
        }
        current = this;

        //切换场景时进行保留
        DontDestroyOnLoad(gameObject);

        ambientSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        fxSource = gameObject.AddComponent<AudioSource>();
        playerSource = gameObject.AddComponent<AudioSource>();
        voiceSource = gameObject.AddComponent<AudioSource>();

        ambientSource.outputAudioMixerGroup = ambientGroup;
        musicSource.outputAudioMixerGroup = musicGroup;
        fxSource.outputAudioMixerGroup = FXGroup;
        playerSource.outputAudioMixerGroup = playerGroup;
        voiceSource.outputAudioMixerGroup = voiceGroup;

        StartLevelAudio();
    }
    //行走音效
    public static void PlayFootstepAudio()
    {
        int index = Random.Range(0, current.walkStepClips.Length);

        current.playerSource.clip = current.walkStepClips[index];
        current.playerSource.Play();
    }
    //下蹲行走音效
    public static void PlayCrouchFootstepAudio()
    {
        int index = Random.Range(0, current.crouchStepClips.Length);

        current.playerSource.clip = current.crouchStepClips[index];
        current.playerSource.Play();
    }
    //环境音效和背景音乐
    void StartLevelAudio()
    {
        current.ambientSource.loop = true;
        current.ambientSource.clip = current.ambientClip;
        current.ambientSource.Play();

        current.musicSource.loop = true;
        current.musicSource.clip = current.musicClip;
        current.musicSource.Play();

        current.fxSource.clip = current.startLevelClip;
        current.fxSource.Play();
    }
    //跳跃音效
    public static void PlayJumpAudio()
    {
        current.playerSource.clip = current.jumpClip;
        current.playerSource.Play();

        current.voiceSource.clip = current.jumpVoiceClip;
        current.voiceSource.Play();
    }
    //死亡音效
    public static void PlayDeathAudio()
    {
        current.playerSource.clip = current.deathClip;
        current.playerSource.Play();

        current.voiceSource.clip = current.deathVoiceClip;
        current.voiceSource.Play();

        current.fxSource.clip = current.deathFXClip;
        current.fxSource.Play();
    }
    //宝珠收集音效
    public static void PlayOrbAudio()
    {
        current.voiceSource.clip = current.orbVoiceClip;
        current.voiceSource.Play();

        current.fxSource.clip = current.orbFXClip;
        current.fxSource.Play();
    }
    //开门音效
    public static void PlayDoorOpenAudio()
    {
        current.fxSource.clip = current.doorFXClip;
        current.fxSource.Play();
    }

    public static void PlayWinAudio()
    {
        current.fxSource.clip = current.winClip;
        current.fxSource.Play();

        current.playerSource.Stop();
    }

    public void SetVolume(float value)
    {
        masterGroup.SetFloat("MainVolume", value);
    }
}
