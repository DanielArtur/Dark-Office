using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    [SerializeField] Animator currentFloorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        currentFloorAnimator.SetTrigger("Close");
        gameObject.SetActive(false);
    }
}
