using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour{

    [SerializeField] private TMP_Text levelNameText;
    [SerializeField] private Button button;

    public void SetLevelName(string name){
        levelNameText.text = name;
    }

    public void SetOpenScene(string scenePath){

        if(!string.IsNullOrEmpty(scenePath)){
            button.onClick.AddListener(() => SceneManager.LoadScene(scenePath));
        }
        else{
            throw new ArgumentException($"Invalid scane name: {scenePath}");
        }

    }

}
