using UnityEngine;

[CreateAssetMenu(fileName = "LevelThemeSO", menuName = "Scriptable Objects/LevelTheme")]
public class LevelThemeSO : ScriptableObject{

    [SerializeField] private LevelThemeReferenceSO levelThemeReference;

    [SerializeField] private SoundArraySO backgroundMusic;
    [SerializeField] private SoundArraySO playerFootstepSound;
    [SerializeField] private SoundArraySO blueEnemyFootstepSound;
    [SerializeField] private SoundArraySO redEnemyFootstepSound;
    [SerializeField] private SoundArraySO batEnemyFlySound;

    public void ApplyTheme(){
        
        levelThemeReference.SetBackgroundMusic(backgroundMusic);
        levelThemeReference.SetPlayerFootstepSound(playerFootstepSound);
        levelThemeReference.SetBlueEnemyFootstepSound(blueEnemyFootstepSound);
        levelThemeReference.SetRedEnemyFootstepSound(redEnemyFootstepSound);
        levelThemeReference.SetbatEnemyFlySound(batEnemyFlySound);

    }

}
