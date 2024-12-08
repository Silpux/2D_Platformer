using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class EnemyDamagable : Enemy, IDamagable{

    [SerializeField] protected int health;
    [SerializeField] protected SoundArraySO damageSound;

    protected Animator animator;
    protected AudioSource audioSource;
    protected int takeDamageAnimationHash;

    protected override void Start(){

        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        takeDamageAnimationHash = Animator.StringToHash("EnemyTakeDamage");

    }

    public void TakeDamage(int amount){

        health -= amount;

        if(health <= 0){
            Die();
            return;
        }

        animator.Play(takeDamageAnimationHash, 1, 0f);
        audioSource.PlayOneShot(damageSound.AudioClips[Random.Range(0, damageSound.AudioClips.Length)]);

    }

    protected void Die(){

        Destroy(gameObject);

    }

}
