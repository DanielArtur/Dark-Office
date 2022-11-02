using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Elevator : MonoBehaviour, IInteraction
{
    //Allun iltasekoilua
    // Pelaajan syöttämä numerosarja hissiin
    [SerializeField] private TMP_InputField passCodeInputField;
    [SerializeField] private CodeTag codeTag;
    static bool isActive = false;
    //public TextMeshProUGUI playerInput;




    // Kun pelaaja interactaa hissin kanssa, hän syöttää 4-numeroisen
    // sarjan numeroita hissikoodiksi, jos tämä on oikein (ja sama mitä koodilapussa),
    // pystyy pelaaja kulkemaan hissillä
    public void Interact()
    {

        if (!isActive)
        {
            passCodeInputField.gameObject.SetActive(true);
            isActive = true;
            Debug.Log("Aktivoitu UI");
        }
        else
        {
            passCodeInputField.gameObject.SetActive(false);
            isActive = false;
            CheckCode();
            Debug.Log("Deaktivoitu UI");
        }
        /*passCodeInputField.SetActive(true);
        passCodeInputField.GetComponent("Text");
         
        
        if (playerInput == randomInput && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("Check Success");
        }*/

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CheckCode()
    {
        if (codeTag.codeStorage != passCodeInputField.text)
            return;
        Debug.Log("Hissi avautuu");
    }
}
