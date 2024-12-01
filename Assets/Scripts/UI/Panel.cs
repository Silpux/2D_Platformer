using UnityEngine;

public abstract class Panel : MonoBehaviour{

    public Panel PreviousPanel{get; protected set;}

    public virtual void SetPreviousPanel(Panel panel){
        PreviousPanel = panel;
    }

    public void OpenPanel(Panel prefab, Panel previousPanel = null){
        PanelManager.Instance.OpenPanel(prefab, CommonParent, previousPanel);
    }

    public virtual void ButtonClose(){
        PanelManager.Instance.ClosePanel(this);
    }

    protected Transform CommonParent => PreviousPanel?.CommonParent ?? transform.parent;

    public virtual bool Close(){

        gameObject.SetActive(false);
        PreviousPanel.gameObject.SetActive(true);
        return true;

    }

}
