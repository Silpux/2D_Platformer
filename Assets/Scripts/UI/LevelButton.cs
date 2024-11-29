using TMPro;
using UnityEngine;

public class LevelButton : MonoBehaviour{

    [SerializeField] private TMP_Text levelNameText;

    public void SetLevelName(string name){
        levelNameText.text = name;
    }

}
