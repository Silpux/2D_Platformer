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

        musicToggle.isOn = musicSettings.Enabled;
        sfxToggle.isOn = sfxSettings.Enabled;

        musicSlider.value = musicSettings.Volume;
        sfxSlider.value = sfxSettings.Volume;

    }

    public void SetMusicValue(float value){
        musicSettings.SetValue(value);
    }

    public void ToggleMusic(bool state){
        musicSettings.Toggle(state);
    }

    public void SetSFXValue(float value){
        sfxSettings.SetValue(value);
    }

    public void ToggleSFX(bool state){
        sfxSettings.Toggle(state);
    }

}
