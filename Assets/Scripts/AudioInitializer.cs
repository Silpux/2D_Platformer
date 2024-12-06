using UnityEngine;

public class AudioInitializer : MonoBehaviour{

    [SerializeField] private AudioMixerSettingsSO[] audioSettings;

    private void Start(){

        foreach(var s in audioSettings){
            s.LoadFromPlayerPrefs();
        }

    }

}
