using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    private AudioSource[] mySounds;

    private AudioSource sound;
    private AudioSource sound2;



    

    //public static AudioManager instance;


    void Awake()
    {

        
    }



    // Start is called before the first frame update
    void Start()
    {

        mySounds = GetComponents<AudioSource>();

        sound = mySounds[0];

        sound2 = mySounds[1];


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlaySound()
    {

        sound.Play();

        print("hello");

    }

    public void PlaySound2()
    {

        sound2.Play();

        print("moi");

    }



}
