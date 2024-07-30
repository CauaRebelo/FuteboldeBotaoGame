using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;

    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("volumeMusica", Mathf.Log10(level) * 20f);
    }
    public void SetSFXVolume(float level)
    {
        audioMixer.SetFloat("volumeSFX", Mathf.Log10(level) * 20f);
    }
}
