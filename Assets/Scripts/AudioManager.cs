using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    private AudioSource[] mySounds;

    private AudioSource menuMusic;
    private AudioSource winMusic;
    private AudioSource chaseMusic;
    private AudioSource ambientMusic;


    void Start()
    {
        mySounds = GetComponents<AudioSource>();

        menuMusic = mySounds[0];

        winMusic = mySounds[1];

        chaseMusic = mySounds[2];

        ambientMusic = mySounds[3];
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
}
