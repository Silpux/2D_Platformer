using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour{

    [SerializeField] protected Vector3[] walkTargets;

    [SerializeField] protected float speed;

    protected int currentTargetIndex = 0;

    protected abstract void Start();

    protected virtual void FixedUpdate(){

        if(transform.position == walkTargets[currentTargetIndex]){

            TargetReached();

            currentTargetIndex = (currentTargetIndex + 1) % walkTargets.Length;

        }

        transform.position = Vector3.MoveTowards(transform.position, walkTargets[currentTargetIndex], speed);

    }

    protected abstract void TargetReached();

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.TryGetComponent<Player>(out Player player)){
            player.Death();
        }
    }

}
