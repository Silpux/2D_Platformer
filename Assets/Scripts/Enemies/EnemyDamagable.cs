using System;
using UnityEngine;

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
    public event Action OnTakeDamage;

    protected AudioSource audioSource;

    protected override void Start(){

        Health = maxHealth;
        audioSource = GetComponent<AudioSource>();

    }

    public void TakeDamage(int amount){

        Health -= amount;

        if(Health <= 0){
            Die();
            return;
        }

        OnTakeDamage?.Invoke();
        audioSource.PlayOneShot(damageSound.AudioClips[UnityEngine.Random.Range(0, damageSound.AudioClips.Length)]);

    }

    protected void Die(){

        Destroy(gameObject);

    }

}
