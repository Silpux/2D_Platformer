using System.Security;
using TMPro;
using UnityEngine;

public class DiamondManager : Singleton<DiamondManager>{

    [SerializeField] private TMP_Text diamondText;

    private int totalDiamonds;
    private int collectedDiamonds;

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
