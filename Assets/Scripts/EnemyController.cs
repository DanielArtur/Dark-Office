using UnityEngine;
using UnityEngine.AI;
using System.Collections;

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

    [Header("Attack")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackEndTime;

    [Header("Other")]
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float sprintingSpeed;
    [SerializeField] private float doorMoveSpeed;
    [SerializeField] private float doorTurnSpeed;

    [SerializeField] private Transform player;

    [Header("Enemy Animator Controller")]
    [SerializeField] private EnemyAnimationController enemyAnimationController;

    private EnemyState state;
    private bool isAttacking;

    public AudioManager AM;

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
        agent.speed = walkingSpeed;

        agent.autoTraverseOffMeshLink = false;
    }

    private void FixedUpdate()
    {
        if (HandleOffMeshLink())
            return;

        if (state == EnemyState.patrol)
            Patrol();
        else if (state == EnemyState.chase)
            Chase();
        else if (state == EnemyState.check)
            Check();
        else if (state == EnemyState.checkturn)
            CheckTurn();
    }

    private bool HandleOffMeshLink()
    {
        if (!agent.isOnOffMeshLink)
            return false;
        if (!agent.currentOffMeshLinkData.offMeshLink)
        {
            agent.CompleteOffMeshLink();
            return true;
        }

        DoorInteraction door = agent.currentOffMeshLinkData.offMeshLink.gameObject.GetComponent<DoorInteraction>();
        if (door == null)
        {
            agent.CompleteOffMeshLink();
            return true;
        }

        if (door.IsOpen)
        {
            Vector3 targetDirection = agent.currentOffMeshLinkData.endPos - transform.position;
            targetDirection.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), doorTurnSpeed);

            Vector3 movement = Vector3.MoveTowards(transform.position, agent.currentOffMeshLinkData.endPos, doorMoveSpeed);
            movement.y = transform.position.y;
            transform.position = movement;

            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(agent.currentOffMeshLinkData.endPos.x, agent.currentOffMeshLinkData.endPos.z)) < 0.01)
            {
                agent.CompleteOffMeshLink();
                door.Interact();
            }
        }
        else if (!door.IsActionRunning)
        {
            door.Interact();
        } 
        
        else
            enemyAnimationController.StartIdleAnimation();

        

        return true;
    }

    private void Chase()
    {
        agent.SetDestination(player.position);

        if (!CheckView())
        {
            state = EnemyState.check;
        }
        else if (!isAttacking)
        {
            Collider[] targets = Physics.OverlapSphere(attackPoint.position, attackDistance);
            for(int i = 0; i < targets.Length; i++)
            {
                if (targets[i].CompareTag("Player"))
                {
                    StartCoroutine(Attack());
                    break;
                }
            }
        }

        enemyAnimationController.StartRunAnimation();
    }

    private IEnumerator Attack()
    {
        isAttacking = true;

        enemyAnimationController.StartAttackAnimation();

        yield return new WaitForSeconds(attackEndTime);

        
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
            agent.speed = walkingSpeed;

           // AM.StopChaseMuscic();
        }
    }

    private void Patrol()
    {
        if (CheckView())
        {
            agent.isStopped = false;
            patrolTurnTarget = null;

            state = EnemyState.chase;
            agent.speed = sprintingSpeed;

            //M.PlayChaseMusic();

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
        else if (agent.remainingDistance < agent.stoppingDistance + 0.5 && !agent.pathPending)
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
