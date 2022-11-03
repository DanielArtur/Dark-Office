using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Navigation")]
    [SerializeField] private NavMeshAgent agent;

    [Header("View")]
    [SerializeField] private Transform eyePoint;
    [SerializeField] private float viewDistance;
    [SerializeField] private float viewAngle;
    [SerializeField] private LayerMask viewBlockingLayers;

    [Header("Patrol")]
    [SerializeField] private PatrolPath patrolPath;
    [SerializeField] private float patrolTurnSpeed;
    private int currentPatrolPoint;
    private Transform patrolTurnTarget;

    [Header("Check Turn")]
    [SerializeField] private float checkTurnSpeed;
    private float checkTurnedAmount;

    [Header("Player")]
    [SerializeField] private Transform player;

    [Header("Enemy Animator Controller")]
    [SerializeField] private EnemyAnimationController enemyAnimationController;

    [Header("Current State")]
    public EnemyState state;

    public enum EnemyState
    {
        patrol,
        chase,
        check,
        checkturn
    }

    private void Start()
    {
        currentPatrolPoint = -1;
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
        else if (state == EnemyState.checkturn)
            CheckTurn();
    }

    private void Chase()
    {
        agent.SetDestination(player.position);

        if (!CheckView())
            state = EnemyState.check;

        enemyAnimationController.StartRunAnimation();
    }

    private void Check()
    {
        if (agent.remainingDistance < agent.stoppingDistance + 0.5)
        {
            state = EnemyState.checkturn;
            checkTurnedAmount = 0;
        }
        else if (CheckView())
        {
            state = EnemyState.chase;
        }
    }

    private void CheckTurn()
    {
        transform.Rotate(0, checkTurnSpeed, 0);
        checkTurnedAmount += checkTurnSpeed;

        enemyAnimationController.StartIdleAnimation();

        if (CheckView())
        {
            state = EnemyState.chase;
        }
        else if(checkTurnedAmount >= 360)
        {
            currentPatrolPoint = -1;
            state = EnemyState.patrol;
        }
    }

    private void Patrol()
    {
        if (CheckView())
        {
            agent.isStopped = false;
            patrolTurnTarget = null;

            state = EnemyState.chase;


        }
        else if (patrolTurnTarget != null)
        {
            agent.isStopped = true;

            Vector3 targetDirection = patrolTurnTarget.position - transform.position;
            targetDirection.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, patrolTurnSpeed);
        
            if(Quaternion.Angle(transform.rotation, targetRotation) < 5)
            {
                agent.isStopped = false;
                patrolTurnTarget = null;
            }
        }
        else if (agent.remainingDistance < agent.stoppingDistance + 0.5)
        {
            NextPatrolPoint();
        }


        enemyAnimationController.StartWalkAnimation();
    }

    public void NextPatrolPoint()
    {
        if (state != EnemyState.patrol)
            return;
        if (patrolPath == null)
            return;
        if (patrolPath.Length() == 0)
            return;

        if (currentPatrolPoint >= 0 && currentPatrolPoint < patrolPath.Length())
            if (patrolPath.GetPoint(currentPatrolPoint).ObjectToLookAt != null)
                patrolTurnTarget = patrolPath.GetPoint(currentPatrolPoint).ObjectToLookAt;

        currentPatrolPoint++;
        if (currentPatrolPoint >= patrolPath.Length())
            currentPatrolPoint = 0;

        agent.SetDestination(patrolPath.GetPoint(currentPatrolPoint).transform.position);
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
