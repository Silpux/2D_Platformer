using UnityEngine;

public class LevelsPanel : Panel{
    public override void Close(){
        gameObject.SetActive(false);
        previousPanel.gameObject.SetActive(true);
    }
}
