using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioMixerSettingsSO", menuName = "Scriptable Objects/AudioMixerSettings")]
public class AudioMixerSettingsSO : ScriptableObject{

    [SerializeField] private AudioMixer audioMixer;
    public AudioMixer AudioMixer => audioMixer;

    [SerializeField] private string parameterName;
    public string ParameterName => parameterName;

    [Header("PlayerPrefs")]
    [SerializeField] private string playerPrefsToggleString;
    public string PlayerPrefsToggleString => playerPrefsToggleString;

    [SerializeField] private string playerPrefsValueString;
    public string PlayerPrefsValueString => playerPrefsValueString;

    private bool enabled;
    public bool Enabled => enabled;
    private float volume;
    public float Volume => volume;

    public void SetValue(float value){

        if(enabled){
            audioMixer.SetFloat(parameterName, Mathf.Log10(value) * 20);
        }

        PlayerPrefs.SetFloat(playerPrefsValueString, value);
        volume = value;

    }

    public void Toggle(bool state){

        if(state){
            audioMixer.SetFloat(parameterName, Mathf.Log10(volume) * 20);
        }
        else{
            audioMixer.SetFloat(parameterName, -80f);
        }

        PlayerPrefs.SetInt(playerPrefsToggleString, state ? 1 : 0);
        enabled = state;

    }

    public void InitializeAudio(){

        enabled = 0 != PlayerPrefs.GetInt(playerPrefsToggleString);
        volume = PlayerPrefs.GetFloat(playerPrefsValueString);

        Toggle(enabled);
        SetValue(volume);

    }

}
