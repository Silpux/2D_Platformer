using UnityEngine;

public class BulletShooter : MonoBehaviour{

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletSpeed;

    [SerializeField] private SoundArraySO shootSounds;
    private AudioSource audioSource;

    private void Start(){

        audioSource = GetComponent<AudioSource>();

    }

    public void Shoot(Vector2 startPosition, Vector2 direction){

        GameObject bullet = Instantiate(bulletPrefab, startPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);

        if(audioSource != null && shootSounds.AudioClips.Length > 0){

            audioSource.PlayOneShot(shootSounds.AudioClips[Random.Range(0, shootSounds.AudioClips.Length)]);

        }

    }

}
