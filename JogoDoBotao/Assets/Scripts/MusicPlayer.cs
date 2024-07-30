using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public AudioSource src;
    public AudioClip musica;
    public AudioClip[] musicas;
    public bool precisaGuardar;
    public bool playonAwake = true;
    public bool multiple = false;
    public float storeTime;
    public float volMusic = 1f;

    void Awake()
    {
        if(!playonAwake)
        {
            return;
        }
        if(GameObject.FindGameObjectWithTag("Music") != null)
        {
            src = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>()._audioSource;
        }
        else
        {
            return;
        }
        if(multiple)
        {
            PlayMultiple();
        }
        else
        {
            if (precisaGuardar)
            {
                storeTime = src.time;
                src.Stop();
                src.clip = musica;
                src.Play();
                src.volume = volMusic;
                src.time = storeTime;
            }
            else
            {
                src.Stop();
                src.clip = musica;
                src.Play();
                src.volume = volMusic;
            }
        }
    }

    public void Play()
    {
        if(GameObject.FindGameObjectWithTag("Music") != null)
        {
            src = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>()._audioSource;
        }
        else
        {
            return;
        }
        if (multiple)
        {
            PlayMultiple();
        }
        else
        {
            if (precisaGuardar)
            {
                storeTime = src.time;
                src.Stop();
                src.clip = musica;
                src.Play();
                src.volume = volMusic;
                src.time = storeTime;
            }
            else
            {
                src.Stop();
                src.clip = musica;
                src.Play();
                src.volume = volMusic;
            }
        }
    }
    void PlayMultiple()
    {
        int rand = Random.Range(0, musicas.Length);
        src.Stop();
        src.clip = musicas[rand];
        src.Play();
        src.volume = volMusic;
    }
}
