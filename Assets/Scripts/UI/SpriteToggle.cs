using UnityEngine;
using UnityEngine.UI;

public class SpriteToggle : MonoBehaviour{

    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite onSprite;

    [SerializeField] private Image image;

    private bool state;

    private void Start(){

        state = GetComponent<Toggle>().isOn;
        UpdateSprite();

    }

    public void SetState(bool state){
        this.state = state;
        UpdateSprite();
    }

    private void UpdateSprite(){

        image.sprite = state ? onSprite : offSprite;

    }

}
