using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BlueEnemy : EnemyDamagable{

    private SpriteRenderer spriteRenderer;
    private EnemyKillZone killZone;

    protected override void Start(){

        base.Start();

        spriteRenderer = GetComponent<SpriteRenderer>();
        killZone = GetComponentInChildren<EnemyKillZone>();

        if(killZone is null){
            throw new NullReferenceException("Kill zone is null");
        }

        killZone.OnTriggered += Die;

    }

    protected override void TargetReached(){

        spriteRenderer.flipX = !spriteRenderer.flipX;

    }

}
