using System;
using UnityEngine;

public class Player : MonoBehaviour{

    [SerializeField] private float walkSpeed = 0.1f;
    [SerializeField] private float swimSpeed = 0.05f;
    [SerializeField] private float waterGravity = 5f;
    [SerializeField] private float runSpeed = 0.15f;
    [SerializeField] private float sneakSpeed = 0.05f;
    [SerializeField] private float swimForce = 1000f;
    [SerializeField] private float jumpForceGround = 8f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float speedOnLadder = 4f;
    [SerializeField] private float additionalGravity = 2400f;

    [SerializeField] private Transform shootPointRight;
    [SerializeField] private Transform shootPointLeft;

    private float speed;

    private bool isGrounded;

    private Vector3 spawnPosition;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    private MoveMode moveMode;

    private Animator animator;

    private GroundedZone groundedZone;
    private BulletShooter bulletShooter;
    private BulletStorage bulletStorage;
    private BulletsUI bulletsUI;

    private enum MoveMode{

        Walk,
        Swim,
        OnLadder

    }

    private void Awake(){

        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        spawnPosition = transform.position;
        groundedZone = GetComponentInChildren<GroundedZone>();
        animator = GetComponent<Animator>();
        bulletShooter = GetComponent<BulletShooter>();
        bulletStorage = GetComponent<BulletStorage>();
        bulletsUI = GetComponent<BulletsUI>();

        if(groundedZone is null){
            throw new NullReferenceException("Grounded zone is null");
        }

        groundedZone.OnGroundStateChanged += SetGrounded;

        if(bulletShooter is null){
            throw new NullReferenceException("Bullet shooter is null");
        }

        if(bulletStorage is null){
            throw new NullReferenceException("Bullet storage is null");
        }
        
        if(bulletsUI is null){
            throw new NullReferenceException("BulletsUI is null");
        }

        bulletStorage.OnBulletCountChanged += bulletsUI.UpdateBulletsCount;

    }

    private void Update(){

        if(Input.GetAxis("Horizontal") != 0){
            spriteRenderer.flipX = Input.GetAxis("Horizontal") > 0;
            animator.Play(Input.GetKey(KeyCode.LeftShift) ? "Sneak" : "Walk");
        }
        else{
            animator.Play("Idle");
        }

        if(rb2d.linearVelocity.y < 0 && moveMode == MoveMode.Walk){
            rb2d.AddForce(-transform.up * additionalGravity * Time.deltaTime);
        }

        switch(moveMode){

            case MoveMode.Swim:

                if(rb2d.linearVelocity.y > -4f){
                    rb2d.AddForce(-transform.up * waterGravity * Time.deltaTime);
                }
                else{
                    rb2d.linearVelocity = new Vector2(0, -4f);
                }

                if(Input.GetKey(KeyCode.Space) && rb2d.linearVelocity.y < 4f){
                    rb2d.AddForce(transform.up * swimForce * Time.deltaTime);
                }

                return;

            case MoveMode.OnLadder:

                transform.position += Input.GetAxis("Vertical") * transform.up * speedOnLadder * Time.deltaTime;

                return;

        }

        if(Input.GetKey(KeyCode.Space) && isGrounded){
            rb2d.linearVelocity = new Vector2(0, jumpForce);
        }

        if(Input.GetKeyDown(KeyCode.Q)){

            if(bulletStorage.ConsumeBullet()){
                bulletShooter.Shoot(shootPointLeft.position, new Vector2(-1f, 0.1f));
            }

        }
        else if(Input.GetKeyDown(KeyCode.E)){

            if(bulletStorage.ConsumeBullet()){
                bulletShooter.Shoot(shootPointRight.position, new Vector2(1f, 0.1f));
            }

        }

    }

    public void SetSpawnPosition(Vector2 position){
        spawnPosition = position;
    }

    public void EnemyKillJump(){
        rb2d.linearVelocity = new Vector2(0, jumpForce / 2);
    }

    private void FixedUpdate(){

        if(moveMode == MoveMode.Swim)
            speed = swimSpeed;
        else
            speed = Input.GetKey(KeyCode.LeftControl) ? runSpeed : Input.GetKey(KeyCode.LeftShift) ? sneakSpeed : walkSpeed;

        transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal") * speed, transform.position.y, transform.position.z);

        rb2d.linearVelocity = new Vector2(0, rb2d.linearVelocity.y);

    }


    private void SwitchMode(MoveMode mode){

        this.moveMode = mode;

        switch(mode){

            case MoveMode.Swim:

                jumpForce = swimForce;
                rb2d.gravityScale = 0f;

                if(rb2d.linearVelocity.y < -7f){
                    rb2d.linearVelocity = new Vector2(0, -7f);
                }
                return;

            case MoveMode.OnLadder:

                rb2d.linearVelocity = Vector2.zero;
                jumpForce = 0f;
                rb2d.gravityScale = 0f;

                return;

        }

        jumpForce = jumpForceGround;
        rb2d.gravityScale = 1f;

    }

    public void Death(){

        transform.position = spawnPosition + transform.up * 0.5f;
        rb2d.linearVelocity = Vector2.zero;

    }

    private void SetGrounded(bool state){

        isGrounded = state;

    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.CompareTag("Deadly")){
            Death();
        }
        else if(other.gameObject.CompareTag("Water")){
            SwitchMode(MoveMode.Swim);
        }
        else if(other.gameObject.CompareTag("Ladder")){
            SwitchMode(MoveMode.OnLadder);
        }

    }

    private void OnTriggerExit2D(Collider2D other){

        if(other.gameObject.CompareTag("Water") || other.gameObject.CompareTag("Ladder")){
            SwitchMode(MoveMode.Walk);
        }

    }

}