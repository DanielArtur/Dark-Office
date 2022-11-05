using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{



    public GameObject losePanel;

    public GameObject mainMenuButton;


    public void loseGame()
    {

        losePanel.SetActive(true);

        mainMenuButton.SetActive(true);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;

        
    }



    public void mainMenu()
    {

        Time.timeScale = 1f;

        SceneManager.LoadScene(0);


    }







}
