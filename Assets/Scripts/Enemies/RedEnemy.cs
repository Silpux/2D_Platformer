using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RedEnemy : EnemyDamagable{

    private SpriteRenderer spriteRenderer;

    protected override void Start(){

        base.Start();

        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    protected override void TargetReached(){

        spriteRenderer.flipX = !spriteRenderer.flipX;

    }

}
