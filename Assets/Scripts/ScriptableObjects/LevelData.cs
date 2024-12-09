using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEditor;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/Level Data")]
public class LevelData : ScriptableObject{

    public List<LevelInfo> levels;

}

[Serializable]
public class LevelInfo{

    [SerializeField] private string name;
    public string Name => name;

    #if UNITY_EDITOR

    [SerializeField] private SceneAsset scene;
    public SceneAsset Scene => scene;

    #endif
    [SerializeField] private LevelThemeSO levelTheme;
    public LevelThemeSO LevelTheme => levelTheme;

    [HideInInspector]
    public string scenePath;

}