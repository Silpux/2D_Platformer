using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonsGenerator : MonoBehaviour{

    [SerializeField] private GameObject levelButtonPrefab;
    [SerializeField] private Transform parent;

    [SerializeField] private LevelData levelData;

    private void Awake(){

        foreach(var level in levelData.levels){

            GameObject button = Instantiate(levelButtonPrefab, parent);

            if(button.TryGetComponent<LevelButton>(out LevelButton levelButton)){

                levelButton.SetLevelName(level.Name);

            }
            else{

                throw new NullReferenceException("LevelButton component is null"); 

            }

        }

    }


}
