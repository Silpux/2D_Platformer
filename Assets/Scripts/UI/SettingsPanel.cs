using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsPanel : Panel{

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioMixerSettingsSO musicSettings;
    [SerializeField] private AudioMixerSettingsSO sfxSettings;

    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Slider musicSlider;

    [SerializeField] private Toggle sfxToggle;
    [SerializeField] private Slider sfxSlider;

    private void Start(){

        musicToggle.isOn = 0 != PlayerPrefs.GetInt(musicSettings.PlayerPrefsEnabledString);
        sfxToggle.isOn = 0 != PlayerPrefs.GetInt(sfxSettings.PlayerPrefsEnabledString);

        musicSlider.value = PlayerPrefs.GetFloat(musicSettings.PlayerPrefsValueString);
        sfxSlider.value = PlayerPrefs.GetFloat(sfxSettings.PlayerPrefsValueString);

    }

    public void SetMusicValue(float value){
        musicSettings.SetValue(value);
        PlayerPrefs.SetFloat(musicSettings.PlayerPrefsValueString, value);
    }

    public void ToggleMusic(bool state){
        musicSettings.Toggle(state);
        PlayerPrefs.SetInt(musicSettings.PlayerPrefsEnabledString, state ? 1 : 0);
    }

    public void SetSFXValue(float value){
        sfxSettings.SetValue(value);
        PlayerPrefs.SetFloat(sfxSettings.PlayerPrefsValueString, value);
    }

    public void ToggleSFX(bool state){
        sfxSettings.Toggle(state);
        PlayerPrefs.SetInt(sfxSettings.PlayerPrefsEnabledString, state ? 1 : 0);
    }

}
