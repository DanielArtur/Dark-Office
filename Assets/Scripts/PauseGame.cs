using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{

    public GameObject continueButton;

    public GameObject mainMenuButton;







    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
