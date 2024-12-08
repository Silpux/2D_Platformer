using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RedEnemy : EnemyDamagable{

    [SerializeField] private SoundArrayReferenceSO footstepSoundReference;

    private SpriteRenderer spriteRenderer;

    protected override void Start(){

        base.Start();

        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void PlayFootstepSound(){

        if(footstepSoundReference?.SoundArray?.AudioClips?.Length > 0){
            audioSource.PlayOneShot(footstepSoundReference.SoundArray.AudioClips[Random.Range(0, footstepSoundReference.SoundArray.AudioClips.Length)]);
        }

    }


    protected override void TargetReached(){

        spriteRenderer.flipX = !spriteRenderer.flipX;

    }

}
