using System;
using UnityEngine;

public class MainPanel : Panel{

    [SerializeField] private Panel levelsPanelPrefab;
    private GameObject levelsPanel;

    public void OpenLevelsPanel(){

        Panel levelsPanel = Instantiate(levelsPanelPrefab, CommonParent);
        levelsPanel.SetPreviousPanel(this);

    }

    public override void SetPreviousPanel(Panel panel){
        throw new InvalidOperationException("Main panel cannot have previous panel");
    }

    public override void Close(){
        throw new InvalidOperationException("Cannot close main panel");
    }

}
