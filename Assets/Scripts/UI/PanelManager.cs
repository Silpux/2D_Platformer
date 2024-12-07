using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PanelManager : Singleton<PanelManager>{

    [SerializeField] private UnityEvent lastPanelClosed;

    private List<Panel> openPanels = new List<Panel>();
    private Dictionary<Panel, Panel> cachedPanels = new Dictionary<Panel, Panel>();

    private void Update(){

        if(Input.GetKeyDown(KeyCode.Escape)){
            CloseLast();
        }

    }

    public Panel OpenPanel(Panel panel, Panel previousPanel = null, bool createNew = false){

        Panel newPanel;

        if(cachedPanels.TryGetValue(panel, out newPanel) && newPanel != null){

            if(createNew){
                Destroy(newPanel.gameObject);
                cachedPanels[panel] = newPanel = Instantiate(panel, transform);
            }
            else{
                newPanel.gameObject.SetActive(true);
            }

        }
        else{
            cachedPanels[panel] = newPanel = Instantiate(panel, transform);
        }

        newPanel.SetPreviousPanel(previousPanel);

        openPanels.Add(newPanel);
        return newPanel;

    }

    public void OpenPanel(Panel panel){
        OpenPanel(panel, null, false);
    }

    public void CloseLast(){

        if(openPanels.Count > 0){

            Panel panel = openPanels[^1];

            panel.Close();
            openPanels.RemoveAt(openPanels.Count - 1);

        }
        else{
            lastPanelClosed.Invoke();
        }

    }

    public void ClosePanel(Panel panel){

        panel.Close();
        openPanels.Remove(panel);

    }

}
