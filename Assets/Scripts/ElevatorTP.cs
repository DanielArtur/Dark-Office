using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTP : MonoBehaviour
{
    //[SerializeField] GameObject elevatorCabinFloor;
    [SerializeField] GameObject playerTransform;
    [SerializeField] Animator elevatorAnimatorTP;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            yield return null;
        

        //ElevatorTP

        playerTransform.transform.position = new Vector3(playerTransform.transform.position.x, playerTransform.transform.position.y + 4.5f, playerTransform.transform.position.z);
        //elevatorCabinFloor.transform.position.y

        yield return new WaitForSeconds(2);

        // Siis help me miten tähän saa animaation liitettyä
        elevatorAnimatorTP.SetBool("canOpen", true);


        //yield return Elevator.elevatorAnimator.SetBool("canOpen", true);

    }
}
