using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioMixerSettingsSO", menuName = "Scriptable Objects/AudioMixerSettingsSO")]
public class AudioMixerSettingsSO : ScriptableObject{

    [SerializeField] private AudioMixer audioMixer;
    public AudioMixer AudioMixer => audioMixer;

    [SerializeField] private string parameterName;
    public string ParameterName => parameterName;

    [SerializeField] private string playerPrefsValueString;
    public string PlayerPrefsValueString => playerPrefsValueString;

    [SerializeField] private string playerPrefsEnabledString;
    public string PlayerPrefsEnabledString => playerPrefsEnabledString;

    private bool enabled;
    private float volume;

    public void SetValue(float value){

        if(enabled){
            audioMixer.SetFloat(parameterName, Mathf.Log10(value) * 20);
        }

        volume = value;

        PlayerPrefs.SetFloat(PlayerPrefsValueString, value);

    }

    public void Toggle(bool state){

        if(state){
            audioMixer.SetFloat(parameterName, Mathf.Log10(volume) * 20);
        }
        else{
            audioMixer.SetFloat(parameterName, -80f);
        }

        enabled = state;

        PlayerPrefs.SetInt(PlayerPrefsEnabledString, state ? 1 : 0);

    }

    public void LoadFromPlayerPrefs(){
        
        enabled = 0 != PlayerPrefs.GetInt(PlayerPrefsEnabledString);
        volume = PlayerPrefs.GetFloat(PlayerPrefsValueString);

        Toggle(enabled);
        SetValue(volume);

    }

}
