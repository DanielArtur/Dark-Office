using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeTag : MonoBehaviour, IInteraction
{
    public TextMeshProUGUI textContainer;
    [HideInInspector] public string codeStorage;
    bool isActive = false;
    [SerializeField] private GameObject UI;
    public void Interact()
    {

        // Silloinkun alueella & E:t� painettu, pelaaja ei pysty liikkumaan kunnes painaa E:t� uudestaan


        //T�h�n lis�t��n canMove == False;

        //Deaktivoidaan Canvas, kun pelaaja painaa E

        if (!isActive)
        {
            UI.gameObject.SetActive(true);
            isActive = true;
            textContainer.text = codeStorage;
            Debug.Log("Aktivoitu UI");
            PlayerMovement.canMove = false;
        }
        else {
            UI.gameObject.SetActive(false);
            isActive = false;
            Debug.Log("Deaktivoitu UI");
            PlayerMovement.canMove = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        codeStorage = Random.Range(0, 10) + "" + Random.Range(0, 10) + "" + Random.Range(0, 10) + "" + Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
