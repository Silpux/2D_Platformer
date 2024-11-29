using System;
using UnityEngine;

public class GroundedZone : MonoBehaviour{

    public event Action<bool> OnGroundStateChanged = delegate{ };

    private void OnTriggerEnter2D(Collider2D other){

        if(other.CompareTag("Ground")){
            OnGroundStateChanged?.Invoke(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Ground")){
            OnGroundStateChanged?.Invoke(false);
        }
    }
}
