using TMPro;
using UnityEngine;

public class BulletsUI : MonoBehaviour{

    [SerializeField] private TMP_Text bulletsText;

    public void UpdateBulletsCount(int amount){
        bulletsText.text = amount.ToString();
    }

}
