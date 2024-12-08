using UnityEngine;

[CreateAssetMenu(fileName = "SoundArrayReferenceSO", menuName = "Scriptable Objects/SoundArrayReference")]
public class SoundArrayReferenceSO : ScriptableObject{

    public SoundArraySO SoundArray{get; set;}

}
