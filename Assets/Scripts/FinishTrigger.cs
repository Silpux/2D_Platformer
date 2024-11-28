using Unity.VisualScripting;
using UnityEngine;

public class FinishTrigger : MonoBehaviour{

    private void OnTriggerEnter2D(Collider2D other){

        if(other.TryGetComponent<Player>(out Player _)){
            Debug.Log("Finish");
        }

    }

}
