using UnityEngine;

public class RedEnemyVisual : MonoBehaviour{

    [SerializeField] private RedEnemy redEnemy;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private int takeDamageAnimationHash;

    private void Start(){

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        takeDamageAnimationHash = Animator.StringToHash("EnemyTakeDamage");

        redEnemy.OnTargetReached += TargetReached;
        redEnemy.OnTakeDamage += TakeDamageAnimation;

    }

    private void TargetReached(){

        spriteRenderer.flipX = !spriteRenderer.flipX;

    }

    private void TakeDamageAnimation(){

        animator.Play(takeDamageAnimationHash, 1, 0f);

    }

    public void Footstep(){

        redEnemy.PlayFootstepSound();

    }

}
