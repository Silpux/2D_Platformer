using UnityEngine;

[CreateAssetMenu(fileName = "SoundArraySO", menuName = "Scriptable Objects/SoundArray")]
public class SoundArraySO : ScriptableObject{

    [SerializeField] private AudioClip[] audioClips;
    public AudioClip[] AudioClips => audioClips;

}
