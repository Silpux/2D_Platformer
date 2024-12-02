using UnityEngine;

public abstract class Panel : MonoBehaviour{

    public Panel PreviousPanel{get; protected set;}

    public virtual void SetPreviousPanel(Panel panel){
        PreviousPanel = panel;
    }

    public void OpenPanel(Panel prefab, Panel previousPanel = null, bool createNew = false){
        PanelManager.Instance.OpenPanel(prefab, transform.parent, previousPanel, createNew);
    }

    public virtual void ButtonClose(){
        PanelManager.Instance.ClosePanel(this);
    }

    public virtual bool Close(){

        gameObject.SetActive(false);
        PreviousPanel.gameObject.SetActive(true);
        return true;

    }

}
