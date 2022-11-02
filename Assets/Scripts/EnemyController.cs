using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Transform eyePoint;
    [SerializeField] private float viewDistance;
    [SerializeField] private float viewAngle;
    [SerializeField] private LayerMask viewBlockingLayers;

    [SerializeField] private PatrolPath patrolPath;
    private int currentPatrolPoint;

    [SerializeField] private Transform player;

    private EnemyState state;

    private enum EnemyState
    {
        patrol,
        chase,
        check
    }

    private void Start()
    {
        currentPatrolPoint = 0;
        state = EnemyState.patrol;
    }

    private void FixedUpdate()
    {
        if (state == EnemyState.patrol)
            Patrol();
        else if (state == EnemyState.chase)
            Chase();
        else if (state == EnemyState.check)
            Check();
    }

    private void Chase()
    {
        agent.SetDestination(player.position);

        if (!CheckView())
            state = EnemyState.check;
    }

    private void Check()
    {
        if (agent.remainingDistance < agent.stoppingDistance + 0.5)
            state = EnemyState.patrol;
        else if (CheckView())
            state = EnemyState.chase;
    }

    private void Patrol()
    {
        if(agent.remainingDistance < agent.stoppingDistance + 0.5)
            NextPatrolPoint();
        if (CheckView())
            state = EnemyState.chase;
    }

    public void NextPatrolPoint()
    {
        if (state != EnemyState.patrol)
            return;
        if (patrolPath == null)
            return;
        if (patrolPath.Length() == 0)
            return;

        agent.SetDestination(patrolPath.GetPoint(currentPatrolPoint).transform.position);

        currentPatrolPoint++;
        if (currentPatrolPoint >= patrolPath.Length())
            currentPatrolPoint = 0;
    }

    private bool CheckView()
    {
        if (Vector3.Distance(eyePoint.position, player.position) > viewDistance)
            return false;
        if(Physics.Linecast(eyePoint.position, player.position, viewBlockingLayers))
            return false;
        if (Vector3.Angle(transform.forward, player.transform.position - transform.position) > viewAngle)
            return false;
        return true;
    }
}
