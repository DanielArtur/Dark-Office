using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{

    public GameObject continueButton;

    public GameObject mainMenuButton;


    void Update()
    {

        if (Input.GetKey(KeyCode.P))
        {

            continueButton.SetActive(true);

            mainMenuButton.SetActive(true);

            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;

        }



    }

    public void ContinueGame()
    {

        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1f;

        continueButton.SetActive(false);

        mainMenuButton.SetActive(false);

        


    }

    public void MainMenu()
    {

        Time.timeScale = 1f;

        SceneManager.LoadScene(0);


    }










}
