using UnityEngine;

public class FishEnemyVisual : MonoBehaviour{

    [SerializeField] private FishEnemy fishEnemy;

    private SpriteRenderer spriteRenderer;

    private void Start(){

        spriteRenderer = GetComponent<SpriteRenderer>();

        fishEnemy.OnTargetReached += TargetReached;

    }

    private void TargetReached(){

        spriteRenderer.flipY = !spriteRenderer.flipY;

    }

}
