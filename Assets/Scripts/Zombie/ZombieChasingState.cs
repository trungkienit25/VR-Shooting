using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieChasingState : StateMachineBehaviour
{

    Transform Player;

    NavMeshAgent agent;
    public float chaseSpeed = 3f;

    public float StopChassingDistance = 21;
    public float attackingDistance = 2.5f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("MainCamera").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        agent.speed = chaseSpeed;   

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(Player.position);
        animator.transform.LookAt(Player);
        
        float distanceFromPlayer = Vector3.Distance(Player.position, animator.transform.position);

        if (distanceFromPlayer > StopChassingDistance)
        {
            animator.SetBool("IsChasing", false);
        }
        if (distanceFromPlayer < attackingDistance)
        {
            animator.SetBool("IsAttacking", true);
        }

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);
    }
}
