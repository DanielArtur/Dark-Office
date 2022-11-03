using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTesti : MonoBehaviour
{

    public AudioManager aM;

    public WinGame LG;

    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {

            aM.PlaySound2();

            LG.winGame();

        }


    }
}
