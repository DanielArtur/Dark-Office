using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour, Interface
{
    bool isActive = false;
    [SerializeField] private GameObject UI;
    public void Interact()
    {
        // Silloinkun alueella & E:t‰ painettu, pelaaja ei pysty liikkumaan kunnes painaa E:t‰ uudestaan
        

        //T‰h‰n lis‰t‰‰n canMove == False;

        //Deaktivoidaan Canvas, kun pelaaja painaa E

        if (!isActive)
        {
            UI.gameObject.SetActive(true);
            isActive = true;
            Debug.Log("Aktivoitu UI");
        }
        else {
            UI.gameObject.SetActive(false);
            isActive = false;
            Debug.Log("Deaktivoitu UI");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
