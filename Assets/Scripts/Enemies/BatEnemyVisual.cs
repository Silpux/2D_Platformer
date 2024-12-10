using UnityEngine;

public class BatEnemyVisual : MonoBehaviour{

    [SerializeField] private BatEnemy enemyBat;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private int takeDamageAnimationHash;

    private void Start(){

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        takeDamageAnimationHash = Animator.StringToHash("EnemyTakeDamage");

        enemyBat.OnTargetReached += TargetReached;
        enemyBat.OnTakeDamage += TakeDamageAnimation;

    }

    private void TargetReached(){

        spriteRenderer.flipX = !spriteRenderer.flipX;

    }

    private void TakeDamageAnimation(){

        animator.Play(takeDamageAnimationHash, 1, 0f);

    }

}
