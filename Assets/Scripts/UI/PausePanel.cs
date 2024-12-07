using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PausePanel : Panel{

    [SerializeField] private Panel settingsPanelPrefab;
    [SerializeField] private GameObject darkBackgroundPrefab;
    private GameObject darkBackground;
    public UnityEvent close;

    private void OnEnable(){

        if(darkBackground == null){
            darkBackground = Instantiate(darkBackgroundPrefab, transform.parent);
            darkBackground.transform.SetSiblingIndex(transform.GetSiblingIndex());
        }
        else{
            darkBackground.gameObject.SetActive(true);
        }

    }

    public void OpenSettingsPanel(){
        OpenPanel(settingsPanelPrefab, this);
        gameObject.SetActive(false);
    }

    public override void Close(){

        darkBackground.gameObject.SetActive(false);
        gameObject.SetActive(false);
        close.Invoke();

    }

    public void Exit(){

        close.Invoke();
        SceneManager.LoadScene(0);

    }

}
