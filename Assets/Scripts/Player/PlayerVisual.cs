using UnityEngine;

public class PlayerVisual : MonoBehaviour{

    [SerializeField] private Player player;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake(){

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        player.OnDirectionChanged += SetDirection;
        player.OnSpeedChanged += PlayAnimation;

    }

    private void SetDirection(bool toRight){
        spriteRenderer.flipX = toRight;
    }

    private void PlayAnimation(Player.WalkSpeed walkSpeed){

        animator.Play(walkSpeed switch{
            Player.WalkSpeed.Idle => "Idle",
            Player.WalkSpeed.Sneak => "Sneak",
            Player.WalkSpeed.Walk => "Walk",
            Player.WalkSpeed.Run => "Walk",
            _ => "Idle"
        });

    }

    public void Footstep(){

        player.PlayFootstepSound();

    }

}
