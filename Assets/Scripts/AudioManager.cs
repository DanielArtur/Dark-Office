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


    

    //public static AudioManager instance;


    void Awake()
    {

        
    }



    // Start is called before the first frame update
    void Start()
    {

        mySounds = GetComponents<AudioSource>();

        menuMusic = mySounds[0];

        winMusic = mySounds[1];

        chaseMusic = mySounds[2];


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayMenuMusic()
    {

        menuMusic.Play();

        print("hello");

    }

    public void PlayWinMusic()
    {

        winMusic.Play();

        print("moi");

    }

    public void PlayChaseMusic()
    {

        chaseMusic.Play();

        
    }

    public void StopChaseMuscic()
    {


        chaseMusic.Stop();


    }


}
