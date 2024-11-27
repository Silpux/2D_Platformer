using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class EnemyDamagable : Enemy{

    protected Animator animator;
    [SerializeField] protected int health;
    protected int takeDamageAnimationHash;

    protected override void Start(){

        animator = GetComponent<Animator>();
        takeDamageAnimationHash = Animator.StringToHash("EnemyTakeDamage");

    }

    protected void TakeDamage(int amount){

        health -= amount;

        if(health <= 0){
            Die();
            return;
        }

        animator.Play(takeDamageAnimationHash, 1, 0f);

    }

    protected void Die(){

        Destroy(gameObject);

    }

}
