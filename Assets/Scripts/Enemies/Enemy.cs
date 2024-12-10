using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour{

    [SerializeField] protected Vector3[] moveTargets;

    [SerializeField] protected float speed;

    public event Action OnTargetReached;

    protected int currentTargetIndex = 0;

    protected abstract void Start();

    protected virtual void FixedUpdate(){

        if(transform.position == moveTargets[currentTargetIndex]){

            OnTargetReached?.Invoke();
            currentTargetIndex = (currentTargetIndex + 1) % moveTargets.Length;

        }

        transform.position = Vector3.MoveTowards(transform.position, moveTargets[currentTargetIndex], speed);

    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.TryGetComponent<Player>(out Player player)){
            player.Death();
        }
    }

}
