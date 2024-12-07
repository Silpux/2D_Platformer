using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioMixerSettingsSO", menuName = "Scriptable Objects/AudioMixerSettingsSO")]
public class AudioMixerSettingsSO : ScriptableObject{

    [SerializeField] private AudioMixer audioMixer;
    public AudioMixer AudioMixer => audioMixer;

    [SerializeField] private string parameterName;
    public string ParameterName => parameterName;

    private bool enabled;
    public bool Enabled => enabled;
    private float volume;
    public float Volume => volume;

    public void SetValue(float value){

        if(enabled){
            audioMixer.SetFloat(parameterName, Mathf.Log10(value) * 20);
        }

        volume = value;

    }

    public void Toggle(bool state){

        if(state){
            audioMixer.SetFloat(parameterName, Mathf.Log10(volume) * 20);
        }
        else{
            audioMixer.SetFloat(parameterName, -80f);
        }

        enabled = state;

    }

    public void InitializeAudio(){

        Toggle(enabled);
        SetValue(volume);

    }

}
