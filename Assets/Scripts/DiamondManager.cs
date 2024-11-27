using System.Security;
using TMPro;
using UnityEngine;

public class DiamondManager : MonoBehaviour{

    public static DiamondManager Instance;

    [SerializeField] private TMP_Text diamondText;

    private int totalDiamonds;
    private int collectedDiamonds;

    private void Awake(){

        if(Instance is null){

            Instance = this;
            return;

        }

        Destroy(gameObject);

    }

    public void RegisterDiamond(Diamond diamond){

        totalDiamonds++;
        UpdateUI();

    }

    public void CollectDiamond(Diamond diamond){

        collectedDiamonds++;
        UpdateUI();

    }

    private void UpdateUI(){

        diamondText.text = $"{collectedDiamonds} / {totalDiamonds}";

    }

}
