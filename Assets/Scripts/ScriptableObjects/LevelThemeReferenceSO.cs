using UnityEngine;

[CreateAssetMenu(fileName = "LevelThemeReferenceSO", menuName = "Scriptable Objects/LevelThemeReference")]
public class LevelThemeReferenceSO : ScriptableObject{

    [SerializeField] private SoundArrayReferenceSO backgroundMusicsReference;
    [SerializeField] private SoundArrayReferenceSO playerFootstepSoundReference;
    [SerializeField] private SoundArrayReferenceSO blueEnemyFootstepSoundReference;
    [SerializeField] private SoundArrayReferenceSO redEnemyFootstepSoundReference;
    [SerializeField] private SoundArrayReferenceSO batEnemyFlySoundReference;

    public void SetBackgroundMusic(SoundArraySO array){
        backgroundMusicsReference.SoundArray = array;
    }

    public void SetPlayerFootstepSound(SoundArraySO array){
        playerFootstepSoundReference.SoundArray = array;
    }

    public void SetBlueEnemyFootstepSound(SoundArraySO array){
        blueEnemyFootstepSoundReference.SoundArray = array;
    }

    public void SetRedEnemyFootstepSound(SoundArraySO array){
        redEnemyFootstepSoundReference.SoundArray = array;
    }

    public void SetbatEnemyFlySound(SoundArraySO array){
        batEnemyFlySoundReference.SoundArray = array;
    }

}
