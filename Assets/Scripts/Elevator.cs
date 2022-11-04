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

    [SerializeField] Animator elevatorAnimator;

    //Oikean kerroken oikea objekti eli TP asetetaan aktiiviseksi
    [SerializeField] GameObject tpObject;



    // Kun pelaaja interactaa hissin kanssa, hän syöttää 4-numeroisen
    // sarjan numeroita hissikoodiksi, jos tämä on oikein (ja sama mitä koodilapussa),
    // pystyy pelaaja kulkemaan hissillä
    public void Interact()
    {

        if (!isActive)
        {
            passCodeInputField.gameObject.SetActive(true);
            passCodeInputField.ActivateInputField();
            isActive = true;

            PlayerMovementv2.lockMovement = true;
            CameraController.lockCamera = true;
            Debug.Log("Aktivoitu UI");
        }
        else
        {
            passCodeInputField.gameObject.SetActive(false);
            isActive = false;
            CheckCode();

            PlayerMovementv2.lockMovement = false;
            CameraController.lockCamera = false;

            // Reset the input
            passCodeInputField.text = "";

            Debug.Log("Deaktivoitu UI");
        }
        /*passCodeInputField.SetActive(true);
        passCodeInputField.GetComponent("Text");
         
        
        if (playerInput == randomInput && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("Check Success");
        }*/

    }

    public void CheckCode()
    {
        if (codeTag.codeStorage != passCodeInputField.text)
            return;

        gameObject.SetActive(false);

        //Asetetaan TP aktiiviseksi
        tpObject.SetActive(true);

        //Debug.Log("Hissi avautuu");
        // Aloita hissi-animaatio
        // Sulje ovet
        // Elevator open doors
        elevatorAnimator.SetTrigger("Open");

        //ELI kun pelaaja saa koodin auki, hissi avautuu,
        //oottaa 2 sekkaa,(kun osuu collideriin (katso ElevatorTP)) hissi sulkeutuu ja kun pelaaja on teleportattu,
        //toisen hissin ovi avautuu ja kun on ulkona(tarvitaan collider) tyylii ovi suljetaan esim.

        //elevatorAnimator.SetBool("canOpen", false);

        //elevatorAnimator.SetBool("canClose", true);

        //elevatorAnimator.SetBool("canClose", false);
        // Joku pelaajan teleporttaus sekä pieni viive
        // Avaa seuraavan kerroksen ovet
        // Sulje niiden ovet
    }
}
