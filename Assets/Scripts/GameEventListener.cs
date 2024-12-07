using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour{

    [SerializeField] private GameEventSO gameEvent;
    public UnityEvent response;

    public void OnEventRaised(){
        response.Invoke();
    }

    private void OnEnable(){
        gameEvent.RegisterListener(this);
    }

    private void OnDisable(){
        gameEvent.UnregisterListener(this);
    }

}
