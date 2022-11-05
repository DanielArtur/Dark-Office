using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioManager AM;
    
    
    // Start is called before the first frame update
    void Start()
    {

        AM.PlayMenuMusic();

    }

    public void StartGame()
    {


        SceneManager.LoadScene(1);


    }

    public void Quit()
    {

        Application.Quit();



    }







}
