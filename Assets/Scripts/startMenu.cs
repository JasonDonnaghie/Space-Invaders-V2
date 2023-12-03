using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    public void startGame(){
        SceneManager.LoadSceneAsync("MainGame");
    }
    public void optionMenu(){
        SceneManager.LoadSceneAsync("Options");
    }
    public void quitGame(){
        Application.Quit();
    }
}
