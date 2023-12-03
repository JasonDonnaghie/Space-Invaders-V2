using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionsMenu : MonoBehaviour
{
    public void backStart(){
        SceneManager.LoadSceneAsync("StartMenu");
    }
    public void qualitySet(int val){
        QualitySettings.SetQualityLevel(val);
    }

    public void fullscreenSet(bool val){
        Screen.fullScreen = val;
    }
}
