using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BlueEnemy : EnemyDamagable{

    [SerializeField] private SoundArrayReferenceSO footstepSoundReference;

    private SpriteRenderer spriteRenderer;
    private EnemyKillZone killZone;

    protected override void Start(){

        base.Start();

        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        killZone = GetComponentInChildren<EnemyKillZone>();

        if(killZone is null){
            throw new NullReferenceException("Kill zone is null");
        }

        killZone.OnTriggered += Die;

    }

    public void PlayFootstepSound(){

        if(footstepSoundReference?.SoundArray?.AudioClips?.Length > 0){
            audioSource.PlayOneShot(footstepSoundReference.SoundArray.AudioClips[UnityEngine.Random.Range(0, footstepSoundReference.SoundArray.AudioClips.Length)]);
        }

    }

    protected override void TargetReached(){

        spriteRenderer.flipX = !spriteRenderer.flipX;

    }

}
