using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Key : MonoBehaviour{

    [SerializeField] private GameObject ClosedObject;

    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.CompareTag("Player")){

            Destroy(this.gameObject);
            Destroy(ClosedObject.gameObject);

        }

    }

}
