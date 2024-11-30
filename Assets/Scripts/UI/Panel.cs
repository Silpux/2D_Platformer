using UnityEngine;

public abstract class Panel : MonoBehaviour{

    protected Panel previousPanel;

    public virtual void SetPreviousPanel(Panel panel){
        previousPanel = panel;
    }

    protected Transform CommonParent => previousPanel?.CommonParent ?? transform.parent;

    public abstract void Close();

}
