using System.Collections.Generic;
using UnityEngine;

public class PanelManager : Singleton<PanelManager>{

    private List<Panel> openPanels = new List<Panel>();
    private Dictionary<Panel, Panel> cachedPanels = new Dictionary<Panel, Panel>();

    [SerializeField] private Panel initialPanel;
    [SerializeField] private Transform parent;

    private void Start(){

        initialPanel = Instantiate(initialPanel, parent);

    }

    private void Update(){

        if(Input.GetKeyDown(KeyCode.Escape)){
            CloseLast();
        }

    }

    public Panel OpenPanel(Panel panel, Transform parent, Panel previousPanel, bool createNew){

        Panel newPanel;

        if(cachedPanels.TryGetValue(panel, out newPanel)){

            if(createNew){
                Destroy(newPanel.gameObject);
                cachedPanels[panel] = newPanel = Instantiate(panel, parent);
            }
            else{
                newPanel.gameObject.SetActive(true);
            }

        }
        else{
            cachedPanels[panel] = newPanel = Instantiate(panel, parent);
        }

        newPanel.SetPreviousPanel(previousPanel);

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
