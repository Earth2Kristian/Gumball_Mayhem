using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemiesScript : MonoBehaviour
{

    private string currentState = "IdleState";
    private NavMeshAgent meshAgent;
    public Transform target;
    public Animator animate;

    public float idleRange = 15;
    public float chaseRange = 7;
    public float attackRange = 2;

    public GameObject attackCollider;

    private float distance;


    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        animate = GetComponent<Animator>();
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance >= chaseRange)
        {
            // If AI is in Idle State
            currentState = "IdleState";
            animate.SetBool("isChasing", false);
            meshAgent.speed = 0f;
            attackCollider.SetActive(false);
        }
        if (distance > attackRange)
        {
            // If AI is in Chasing State
            currentState = "ChaseState";
            animate.SetBool("isChasing", true);
            animate.SetBool("isAttacking", false);
            meshAgent.SetDestination(target.position);
            meshAgent.speed = 3.5f;
            attackCollider.SetActive(false);

        }
        if (distance <= attackRange)
        {
            // If AI is in Attackibg State
            currentState = "AttackState";
            animate.SetInteger("attackIndex", Random.Range(0, 2));
            animate.SetBool("isAttacking", true);
            meshAgent.speed = 0f;
            attackCollider.SetActive(true);

        }

    }
}
