using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get => instance; }

    private AudioSource[] mySounds;

    private AudioSource menuMusic;
    private AudioSource winMusic;
    private AudioSource chaseMusic;
    private AudioSource ambientMusic;

    private AudioSource doorSound;


    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        mySounds = GetComponents<AudioSource>();

        menuMusic = mySounds.Length < 1 ? null : mySounds[0];

        winMusic = mySounds.Length < 2 ? null : mySounds[1];

        chaseMusic = mySounds.Length < 3 ? null : mySounds[2];

        ambientMusic = mySounds.Length < 4 ? null : mySounds[3];

        doorSound = mySounds.Length < 5 ? null : mySounds[4];
    }


    public void PlayMenuMusic()
    {
        menuMusic.Play();
    }

    public void PlayWinMusic()
    {
        winMusic.Play();
    }

    public void PlayChaseMusic()
    {
        chaseMusic.Play();
    }

    public void StopChaseMuscic()
    {
        chaseMusic.Stop();
    }

    public void PlayAmbientMusic()
    {
        ambientMusic.Play();
    }

    public void StopAmbientMuscic()
    {
        ambientMusic.Stop();
    }

    public void PlayDoorSound()
    {
        doorSound.Play();
    }
}
