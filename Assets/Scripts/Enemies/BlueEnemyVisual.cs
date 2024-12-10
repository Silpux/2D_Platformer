using UnityEngine;

public class BlueEnemyVisual : MonoBehaviour{

    [SerializeField] private BlueEnemy blueEnemy;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private int takeDamageAnimationHash;

    private void Start(){

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        takeDamageAnimationHash = Animator.StringToHash("EnemyTakeDamage");

        blueEnemy.OnTargetReached += TargetReached;
        blueEnemy.OnTakeDamage += TakeDamageAnimation;

    }

    private void TargetReached(){

        spriteRenderer.flipX = !spriteRenderer.flipX;

    }

    private void TakeDamageAnimation(){

        animator.Play(takeDamageAnimationHash, 1, 0f);

    }

    public void Footstep(){

        blueEnemy.PlayFootstepSound();

    }

}
