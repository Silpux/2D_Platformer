using UnityEngine;

public class BulletBox : MonoBehaviour{

    [SerializeField] private int bulletCount;

    private void OnCollisionEnter2D(Collision2D other){

        if(other.gameObject.TryGetComponent<BulletStorage>(out BulletStorage bulletStorage)){
            bulletStorage.AddBullets(bulletCount);
            Destroy(gameObject);
        }

    }

}
