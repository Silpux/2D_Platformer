using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour{

    private void OnTriggerEnter2D(Collider2D other){

        if(other.TryGetComponent<Player>(out Player _)){
            SceneManager.LoadScene(0);
        }

    }

}
