#if UNITY_EDITOR

using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(LevelInfo))]
public class SceneReferenceDrawer : PropertyDrawer{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label){

        EditorGUI.BeginProperty(position, label, property);

        var sceneNameProp = property.FindPropertyRelative("name");

        if(sceneNameProp is null){
            throw new NullReferenceException("Scene name property is null");
        }

        var sceneAssetProp = property.FindPropertyRelative("scene");

        if(sceneAssetProp is null){
            throw new NullReferenceException("Scene asset property is null");
        }

        var scenePathProp = property.FindPropertyRelative("scenePath");

        if(scenePathProp is null){
            throw new NullReferenceException("Scene path property is null");
        }

        Rect assetFieldRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        Rect nameFieldRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + 2, position.width, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(assetFieldRect, sceneAssetProp, new GUIContent("Scene"));

        if(sceneAssetProp.objectReferenceValue is not null){
            string scenePath = System.IO.Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(sceneAssetProp.objectReferenceValue));
            scenePathProp.stringValue = scenePath;
        }
        else{
            throw new ArgumentException("Value is not valid");
        }

        sceneNameProp.stringValue = EditorGUI.TextField(nameFieldRect, "Level Name", sceneNameProp.stringValue);

        EditorGUI.EndProperty();

    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label){
        return EditorGUIUtility.singleLineHeight * 2 + 4;
    }

}

#endif