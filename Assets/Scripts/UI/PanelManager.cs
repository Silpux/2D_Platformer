using System.Collections.Generic;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>{

    private List<Panel> openPanels = new List<Panel>();
    private Dictionary<Panel, Panel> cachedPanels = new Dictionary<Panel, Panel>();

    [SerializeField] private Panel initialPanel;

    private void Update(){

        if(Input.GetKeyDown(KeyCode.Escape)){
            CloseLast();
        }

    }

    public Panel OpenPanel(Panel panel, Transform parent, Panel previousPanel = null){

        Panel newPanel;

        if(cachedPanels.TryGetValue(panel, out newPanel)){
            newPanel.gameObject.SetActive(true);
        }
        else{
            newPanel = Instantiate(panel, parent);
            cachedPanels[panel] = newPanel;
        }

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
            initialPanel.Close();
        }

    }

    public void ClosePanel(Panel panel){

        if(panel.Close()){
            openPanels.Remove(panel);
        }

    }

}
