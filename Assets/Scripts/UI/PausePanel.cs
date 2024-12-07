using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PausePanel : Panel{

    [SerializeField] private Panel settingsPanelPrefab;
    public UnityEvent close;

    public void OpenSettingsPanel(){
        OpenPanel(settingsPanelPrefab, this);
        gameObject.SetActive(false);
    }

    public override void Close(){

        gameObject.SetActive(false);
        close.Invoke();

    }

    public void Exit(){

        close.Invoke();
        SceneManager.LoadScene(0);

    }

}
