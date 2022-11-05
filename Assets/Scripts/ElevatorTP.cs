using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTP : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] GameObject playerTransform;

    [Header("Animators")]
    [SerializeField] Animator upperFloorAnimator;
    [SerializeField] Animator currentFloorAnimator;

    [Header("Teleportation")]
    [SerializeField] float tpHeight;
    [SerializeField] float tpWaitTime = 2.5f;

    [Header("Enemy")]
    [SerializeField] private GameObject upperFloorEnemy;
    [SerializeField] private GameObject currentFloorEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        StartCoroutine(TPWaitTime());
    }

    private IEnumerator TPWaitTime()
    {
        currentFloorAnimator.SetTrigger("Close");

        if (upperFloorEnemy != null)
            upperFloorEnemy.SetActive(true);

        yield return new WaitForSeconds(tpWaitTime);

        playerTransform.transform.position = new Vector3(playerTransform.transform.position.x, tpHeight, playerTransform.transform.position.z);
        
        upperFloorAnimator.SetTrigger("Open");

        if (currentFloorEnemy != null)
            currentFloorEnemy.SetActive(false);
    }
}
