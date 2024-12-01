using UnityEngine;

public class LevelsPanel : Panel{

    public override bool Close(){

        gameObject.SetActive(false);
        PreviousPanel.gameObject.SetActive(true);
        return true;

    }

    public void ButtonClose(){
        PanelManager.Instance.ClosePanel(this);
    }
}
