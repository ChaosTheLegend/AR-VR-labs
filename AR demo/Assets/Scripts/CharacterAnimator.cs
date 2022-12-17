using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayDeath()
    {
        animator.SetTrigger("Death");
    }
    
    public void PlayAttack()
    {
        animator.SetTrigger("Attack");
    }
    
    public void PlayDamage()
    {
        animator.SetTrigger("Damage");
    }
    
    public void PlayRespawn()
    {
        animator.SetTrigger("Respawn");
    }
}
