using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{

    public GameObject losePanel;

    public GameObject mainMenuButton;








    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

        SceneManager.LoadScene(1);


    }







}
