using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] LayerMask interactLayer;
    public float radius;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, interactLayer);
            foreach (var hitCollider in hitColliders)
            {
                IInteraction interaction = hitCollider.GetComponent<IInteraction>();
                if (interaction != null)
                    interaction.Interact();
                
            }
        }
    }
    
}
