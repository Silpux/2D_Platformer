using System;
using UnityEngine;

public class MainPanel : Panel{

    [SerializeField] private Panel levelsPanelPrefab;
    [SerializeField] private Panel exitPanelPrefab;

    public void OpenLevelsPanel(){

        OpenPanel(levelsPanelPrefab, this, true);
        gameObject.SetActive(false);

    }

    public void OpenExitPanel(){
        OpenPanel(exitPanelPrefab, this);
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
