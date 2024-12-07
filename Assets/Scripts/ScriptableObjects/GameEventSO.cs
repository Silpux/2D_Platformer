using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEventSO", menuName = "Scriptable Objects/GameEvent")]
public class GameEventSO : ScriptableObject{

    public List<GameEventListener> listeners = new List<GameEventListener>();

    public void RaiseEvent(){
        for(int i = listeners.Count - 1;i>=0;i--){
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener l){
        if(!listeners.Contains(l)){
            listeners.Add(l);
        }
    }

    public void UnregisterListener(GameEventListener l){
        listeners.Remove(l);
    }

}
