using UnityEngine;

public class ExitPanel : Panel{

    public void ExitButton(){
        Debug.Log("Quit");
        Application.Quit();
    }

}
