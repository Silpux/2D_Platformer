using UnityEngine;
using UnityEngine.Audio;

public class BackgroundMusic : MonoBehaviour{

    [SerializeField] private AudioMixerSnapshot normalSnapshot;
    [SerializeField] private AudioMixerSnapshot pausedSnapshot;

    public void SetPausedMode(){
        pausedSnapshot.TransitionTo(0.1f);
    }

    public void SetNormalMode(){
        normalSnapshot.TransitionTo(0.1f);
    }

}
