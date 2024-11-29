using UnityEngine;

public class BulletShooter : MonoBehaviour{

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletSpeed;

    public void Shoot(Vector2 startPosition, Vector2 direction){

        GameObject bullet = Instantiate(bulletPrefab, startPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);

    }

}
