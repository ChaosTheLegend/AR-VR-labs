using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int health = 100;
    private CharacterAnimator anim;
    private bool isDead = false;
    private void Awake()
    {
        anim = GetComponent<CharacterAnimator>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
            return;
        }
        anim.PlayDamage();

    }

    private void Die()
    {
        if(isDead) return;
        isDead = true;
        anim.PlayDeath();
        
        Invoke(nameof(Respawn), 5f);
    }

    private void Respawn()
    {
        if(!isDead) return;
        
        anim.PlayRespawn();
        health = 5;
        isDead = false;
    }
}
