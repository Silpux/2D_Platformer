using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class EnemyDamagable : Enemy, IDamagable, IHealthBar{

    private int health;
    protected int Health{

        get => health;

        set{
            health = value;
            OnHealthChanged?.Invoke(this, new IHealthBar.HealthChangedEventArgs((float)health / maxHealth));
        }

    }

    [SerializeField] int maxHealth;
    [SerializeField] protected SoundArraySO damageSound;

    public event EventHandler<IHealthBar.HealthChangedEventArgs> OnHealthChanged;

    protected Animator animator;
    protected AudioSource audioSource;
    protected int takeDamageAnimationHash;

    protected override void Start(){

        Health = maxHealth;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        takeDamageAnimationHash = Animator.StringToHash("EnemyTakeDamage");

    }

    public void TakeDamage(int amount){

        Health -= amount;

        if(Health <= 0){
            Die();
            return;
        }

        animator.Play(takeDamageAnimationHash, 1, 0f);
        audioSource.PlayOneShot(damageSound.AudioClips[UnityEngine.Random.Range(0, damageSound.AudioClips.Length)]);

    }

    protected void Die(){

        Destroy(gameObject);

    }

}
