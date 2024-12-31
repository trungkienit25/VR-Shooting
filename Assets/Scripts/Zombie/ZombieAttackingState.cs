using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAttackingState : StateMachineBehaviour
{

    Transform Player;

    NavMeshAgent agent;

    public float StopAttackingDistance = 2.5f;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("MainCamera").transform;
        agent = animator.GetComponent<NavMeshAgent>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LookAtPlayer();

        float distanceFromPlayer = Vector3.Distance(Player.position, animator.transform.position);

        if (distanceFromPlayer > StopAttackingDistance)
        {
            animator.SetBool("IsAttacking", false);
        }

    }


    private void LookAtPlayer()
    {
        Vector3 direction = Player.position - agent.transform.position;
        agent.transform.rotation = Quaternion.LookRotation(direction);

        var yRotation = agent.transform.eulerAngles.y;
        agent.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}