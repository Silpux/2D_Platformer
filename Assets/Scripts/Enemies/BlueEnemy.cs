using UnityEngine;

public class BlueEnemy : EnemyDamagable{

    [SerializeField] private SoundArrayReferenceSO footstepSoundReference;
    [SerializeField] private EnemyKillZone killZone;

    protected override void Start(){

        base.Start();

        audioSource = GetComponent<AudioSource>();
        killZone.OnTriggered += Die;

    }

    public void PlayFootstepSound(){

        if(footstepSoundReference?.SoundArray?.AudioClips?.Length > 0){
            audioSource.PlayOneShot(footstepSoundReference.SoundArray.AudioClips[UnityEngine.Random.Range(0, footstepSoundReference.SoundArray.AudioClips.Length)]);
        }

    }

}
