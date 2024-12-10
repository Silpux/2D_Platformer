using UnityEngine;

public class RedEnemy : EnemyDamagable{

    [SerializeField] private SoundArrayReferenceSO footstepSoundReference;

    protected override void Start(){

        base.Start();
        audioSource = GetComponent<AudioSource>();

    }

    public void PlayFootstepSound(){

        if(footstepSoundReference?.SoundArray?.AudioClips?.Length > 0){
            audioSource.PlayOneShot(footstepSoundReference.SoundArray.AudioClips[Random.Range(0, footstepSoundReference.SoundArray.AudioClips.Length)]);
        }

    }

}
