using UnityEngine;

public class Diamond : MonoBehaviour{

    private void Start(){

        DiamondManager.Instance.RegisterDiamond(this);

    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.TryGetComponent<Player>(out Player _)){
            DiamondManager.Instance.CollectDiamond(this);
            Destroy(gameObject);
        }

    }

}
