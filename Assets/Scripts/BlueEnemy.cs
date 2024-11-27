using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class BlueEnemy : Enemy{

    private SpriteRenderer spriteRenderer;

    [SerializeField] private int health;

    private EnemyKillZone killZone;
    private Animator animator;
    private int takeDamageAnimationHash;

    protected override void Start(){

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        takeDamageAnimationHash = Animator.StringToHash("EnemyTakeDamage");

        killZone = GetComponentInChildren<EnemyKillZone>();

        if(killZone is null){
            throw new NullReferenceException("Kill zone is null");
        }

        killZone.OnTriggered += Die;

    }

    protected override void TargetReached(){

        spriteRenderer.flipX = !spriteRenderer.flipX;

    }

    private void TakeDamage(int amount){

        health -= amount;

        if(health <= 0){
            Die();
            return;
        }

        animator.Play(takeDamageAnimationHash, 1, 0f);

    }



    private void Die(){

        Destroy(gameObject);

    }

}
