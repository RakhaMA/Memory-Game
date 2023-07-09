using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject timerPanel;

    private void Start() {
        mainPanel.SetActive(true);
        timerPanel.SetActive(false);
    }

    public void PlayButton(){
        mainPanel.SetActive(false);
        timerPanel.SetActive(true);
    }

    public void SetTimerButton(float timer){
        GameData.instance.gameTimer = timer;
        SceneManager.LoadScene("Gameplay");
    }


    public void ExitGame(){
        Application.Quit();
    }
}
