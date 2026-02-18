using UnityEngine;
using UnityEngine.AI;

public class HunterMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;

    private float detectionRadius = 15f;
    private float patrolRadius = 20f;
    private float patrolIdleTime = 2f;

    private bool isPatroling = false;
    private bool isIdle = false;

    private float cooldown;
    private float idleTimer;
    
    private Vector3 patrolPoint;
    private enum State
    {
        Patrol,
        Chase
    }

    private State state;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        SetNewPatrolPath();
        state = State.Patrol;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= detectionRadius)
        {
            state = State.Chase;
        }
        else
        {
            state = State.Patrol;
        }

        switch (state)
        {
            case State.Patrol: Patrol(); break;
            case State.Chase: Chase(); break;
        }
    }

    private void Patrol()
    {
        if (isIdle)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= patrolIdleTime)
            {
                SetNewPatrolPath();
                idleTimer = 0;
            }
        }

        if (!isPatroling || Vector3.Distance(transform.position, patrolPoint) < 1.5f)
        {
            isIdle = true;
            isPatroling = false;
            agent.ResetPath();
        }
    }

    private void Chase()
    {
        if (target == null) return;
        if (!agent.isOnNavMesh) return;
        
        isIdle = false;
        isPatroling = false;
        
        agent.SetDestination(target.position);
    }
    
    private void SetNewPatrolPath()
    {
        Vector3 random = Random.insideUnitSphere * patrolRadius + transform.position;

        if (NavMesh.SamplePosition(random, out NavMeshHit hit, patrolRadius, NavMesh.AllAreas))
        {
            patrolPoint = hit.position;
            agent.SetDestination(patrolPoint);
            isPatroling = true;
            isIdle = false;
        }
        
    }
}