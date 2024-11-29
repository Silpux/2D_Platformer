using UnityEngine;

public class FishEnemy : Enemy{

    private SpriteRenderer spriteRenderer;

    protected override void Start(){

        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    protected override void TargetReached(){

        spriteRenderer.flipY = !spriteRenderer.flipY;

    }

}
