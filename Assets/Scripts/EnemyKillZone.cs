using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyKillZone : MonoBehaviour{

    public event Action OnTriggered = delegate{ };

    private void OnTriggerEnter2D(Collider2D other){

        if(other.TryGetComponent<Player>(out Player player)){
            OnTriggered?.Invoke();
            player.EnemyKillJump();
        }

    }

}
