using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour{

    [SerializeField] private int damage = 35;

    private void Start(){

        Destroy(gameObject, 3f);

    }

    private void OnCollisionEnter2D(Collision2D other){

        if(!other.gameObject.TryGetComponent<Player>(out Player _)){
            Destroy(gameObject);
        }

        if(other.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable)){
            damagable.TakeDamage(damage);
        }

    }

}
