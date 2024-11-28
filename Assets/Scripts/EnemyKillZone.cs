using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyKillZone : MonoBehaviour{

    public event Action OnTriggered = delegate{ };

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.TryGetComponent<Player>(out Player player)){
            OnTriggered?.Invoke();
            player.EnemyKillJump();
        }
    }

}
