using System;
using UnityEngine;

public class MainPanel : Panel{

    [SerializeField] private Panel levelsPanelPrefab;
    [SerializeField] private Panel exitPanelPrefab;
    [SerializeField] private Panel settingsPanelPrefab;

    public void OpenLevelsPanel(){
        OpenPanel(levelsPanelPrefab, this);
        gameObject.SetActive(false);
    }

    public void OpenExitPanel(){
        OpenPanel(exitPanelPrefab, this);
        gameObject.SetActive(false);
    }

    public void OpenSettingsPanel(){
        OpenPanel(settingsPanelPrefab, this);
        gameObject.SetActive(false);
    }

    public override void SetPreviousPanel(Panel panel){
        throw new InvalidOperationException("Main panel cannot have previous panel");
    }

    public override bool Close(){
        OpenExitPanel();
        return true;
    }

}
