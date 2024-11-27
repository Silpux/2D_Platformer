using UnityEngine;

public class BulletShooter : MonoBehaviour{

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletVerticalImpulse;

    [SerializeField] private Transform shootPointRight;
    [SerializeField] private Transform shootPointLeft;

    public void Shoot(bool toRight){

        GameObject bullet;
        if(toRight){
            bullet = Instantiate(bulletPrefab, shootPointRight.position, Quaternion.identity);
        }
        else{
            bullet = Instantiate(bulletPrefab, shootPointLeft.position, Quaternion.identity);
        }

        bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(toRight ? bulletSpeed : -bulletSpeed, bulletVerticalImpulse), ForceMode2D.Impulse);

    }

}
