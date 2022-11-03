using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTP : MonoBehaviour
{
    //[SerializeField] GameObject elevatorCabinFloor;
    [SerializeField] GameObject playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        //ElevatorTP

        playerTransform.transform.position = new Vector3(playerTransform.transform.position.x, playerTransform.transform.position.y + 4.5f, playerTransform.transform.position.z);
        //elevatorCabinFloor.transform.position.y
        
    }
}
