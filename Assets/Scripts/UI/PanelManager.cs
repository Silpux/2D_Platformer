using System.Collections.Generic;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>{

    private List<Panel> openPanels = new List<Panel>();

    private void Update(){

        if(Input.GetKey(KeyCode.Escape)){
            CloseLast();
        }

    }

    public Panel OpenPanel(Panel panel, Transform parent, Panel previousPanel = null){

        Panel newPanel = Instantiate(panel, parent);

        if(previousPanel is not null){
            newPanel.SetPreviousPanel(previousPanel);
        }

        openPanels.Add(newPanel);
        return newPanel;

    }

    public void CloseLast(){

        if(openPanels.Count > 0){

            Panel panel = openPanels[^1];

            if(panel.Close()){

                openPanels.RemoveAt(openPanels.Count - 1);

            }

        }
        else{

        }

    }

    public void ClosePanel(Panel panel){

        if(panel.Close()){
            openPanels.Remove(panel);
        }

    }

}
