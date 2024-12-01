using System;
using UnityEngine;

public class MainPanel : Panel{

    [SerializeField] private Panel levelsPanelPrefab;

    public void OpenLevelsPanel(){

        PanelManager.Instance.OpenPanel(levelsPanelPrefab, CommonParent, this);
        gameObject.SetActive(false);

    }

    public override void SetPreviousPanel(Panel panel){
        throw new InvalidOperationException("Main panel cannot have previous panel");
    }

    public override bool Close(){
        throw new InvalidOperationException("Cannot close main panel");
    }

}
