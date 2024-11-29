using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/Level Data")]
public class LevelData : ScriptableObject{

    public List<LevelInfo> levels;

}

[Serializable]
public class LevelInfo{

    [SerializeField] private string name;
    public string Name => name;

    [SerializeField] private SceneAsset scene;
    public SceneAsset Scene => scene;


}