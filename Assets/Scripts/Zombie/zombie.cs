using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : EnemyGeneral, ITakeDamage
{

    [SerializeField] private float HP = 100;

    private Animator animator;
    private NavMeshAgent navAgent;
    [SerializeField] private ParticleSystem bloodSplatterFX;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
{
    HP -= weapon.GetDamage();
    if (HP <= 0)
    {
            if (!isDead)
            {
                int randomvalue = Random.Range(0, 2);
                if (randomvalue == 0)
                {
                    animator.SetTrigger("DIE1");
                }
                else
                {
                    animator.SetTrigger("DIE2");
                }
                isDead = true;
            }
       
    }
    else
    {
            ParticleSystem effect = Instantiate(bloodSplatterFX, contactPoint, Quaternion.LookRotation(weapon.transform.position - contactPoint));
            animator.SetTrigger("DAMAGE");
    }
}
}


