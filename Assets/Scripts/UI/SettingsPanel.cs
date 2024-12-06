using UnityEngine;
using UnityEngine.Audio;

public class SettingsPanel : Panel{

    [SerializeField] private AudioMixer audioMixer;

    private const string MusicGroupParam = "MusicGroup";
    private const string MusicParam = "MusicVolume";
    private const string SFXGroupParam = "SFXGroup";
    private const string SFXParam = "SFXVolume";

    public void SetMusicValue(float value){
        audioMixer.SetFloat(MusicParam, Mathf.Log10(value) * 20);
    }

    public void ToggleMusic(bool state){
        audioMixer.SetFloat(MusicGroupParam, state ? 0f : -80f);
    }

    public void SetSFXValue(float value){
        audioMixer.SetFloat(SFXParam, Mathf.Log10(value) * 20);
    }

    public void ToggleSFX(bool state){
        audioMixer.SetFloat(SFXGroupParam, state ? 0f : -80f);
    }

}
