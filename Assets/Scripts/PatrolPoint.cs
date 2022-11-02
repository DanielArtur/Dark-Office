using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy"))
            return;

        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy == null)
            return;

        //enemy.NextPatrolPoint();
    }
}
