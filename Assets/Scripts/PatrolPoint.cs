using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    [SerializeField] private Transform objectToLookAt;
    public Transform ObjectToLookAt { get => objectToLookAt; }
}
