using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script controls the animation of the enemy
/// </summary>
public class EnemyAnimationController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Animator animator;


    
    public void StartIdleAnimation()
    {

        animator.SetBool("Idle", true);
        animator.SetBool("Walk", false);
        animator.SetBool("Run", false);
    }

    public void StartWalkAnimation()
    {
        animator.SetBool("Walk", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Run", false);
    }

    public void StartRunAnimation()
    {

       
        animator.SetBool("Run", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Walk", false);
    }

    public void StartAttackAnimation()
    {
        animator.SetTrigger("Punch");
    }
}
