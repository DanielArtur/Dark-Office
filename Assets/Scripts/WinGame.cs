using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{

    public GameObject winPanel;

    public GameObject mainMenuButton;





    // Start is called before the first frame update
    void Start()
    {

        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void winGame()
    {

        winPanel.SetActive(true);

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
