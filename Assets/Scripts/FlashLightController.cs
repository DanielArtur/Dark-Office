using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour
{
    [Header("Flash Light")]
    [SerializeField] GameObject flashLight;


    void Update()
    {
        if (Input.GetButtonDown("FlashLight") && !flashLight.activeSelf)
            flashLight.SetActive(true);



        else if (Input.GetButtonDown("FlashLight"))
            flashLight.SetActive(false);


    }

}
