using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    [SerializeField] private PatrolPoint[] patrolPoints;

    public PatrolPoint GetPoint(int index)
    {
        return patrolPoints[index];
    }

    public int Length()
    {
        return patrolPoints.Length;
    }
}
