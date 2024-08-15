using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public enum SFX
{
    PlayerWalk,
    PlayerJump,
    PlayerAttack,
    PlayerHurt,
    PlayerDeath,
    ButtonClick
}

public enum MixerGroup
{
    Master,
    SFX,
    Environment
}

[Serializable]
struct SFXConfig
{
    public SFX Type;
    public AudioClip AudioClip;
    public float VolumeScale;
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer AudioMixer;
    [SerializeField] private AudioSource SFXAudioSource;
    [SerializeField] private AudioSource EnvironmentAudioSource;
    [SerializeField] private SFXConfig[] SFXConfigs;

    private Dictionary<SFX, SFXConfig> SFXs;
    private Dictionary<MixerGroup, string> MixerGroups;

    private void Awake()
    {
        MixerGroups = new()
        {
            { MixerGroup.Master, "MasterVolume" },
            { MixerGroup.SFX, "SFXVolume" },
            { MixerGroup.Environment, "EnvironmentVolume" }
        };

        SFXs = SFXConfigs.ToDictionary(sfxConfig => sfxConfig.Type, sfxConfig => sfxConfig);
    }

    public void PlaySFX(SFX type)
    {
        if (SFXs.ContainsKey(type))
        {
            SFXConfig config = SFXs[type];
            SFXAudioSource.PlayOneShot(config.AudioClip, config.VolumeScale);
        }
    }

    public void SetMixerVolume(MixerGroup group, float normalizedValue)
    {
        string groupString = MixerGroups[group];
        float volume = Mathf.Log10(normalizedValue) * 20;
        AudioMixer.SetFloat(groupString, volume);
    }

    public float GetMixerVolume(MixerGroup group, bool normalize = true)
    {
        string groupString = MixerGroups[group];
        AudioMixer.GetFloat(groupString, out float volume);

        if (normalize)
        {
            volume = Mathf.Pow(10, volume / 20);
        }

        return volume;
    }
}