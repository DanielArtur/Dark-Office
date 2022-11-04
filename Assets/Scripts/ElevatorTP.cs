using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTP : MonoBehaviour
{
    //[SerializeField] GameObject elevatorCabinFloor;
    [SerializeField] GameObject playerTransform;
    [SerializeField] Animator upperFloorAnimator;
    [SerializeField] Animator currentFloorAnimator;
    [SerializeField] float tpHeight;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        StartCoroutine(TPWaitTime());
        Debug.Log("CheckTP");
    }

    private IEnumerator TPWaitTime()
    {
        currentFloorAnimator.SetTrigger("Close");
        yield return new WaitForSeconds(2);

        //ElevatorTP

        playerTransform.transform.position = new Vector3(playerTransform.transform.position.x, tpHeight, playerTransform.transform.position.z);
        //elevatorCabinFloor.transform.position.y

        

        // Siis help me miten tähän saa animaation liitettyä
        upperFloorAnimator.SetTrigger("Open");


        //yield return Elevator.elevatorAnimator.SetBool("canOpen", true);

    }
}
