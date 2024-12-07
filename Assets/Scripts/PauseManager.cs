using UnityEngine;

public class PauseManager : MonoBehaviour{

    public void Pause(){
        Time.timeScale = 0f;
    }

    public void Continue(){
        Time.timeScale = 1f;
    }

}
