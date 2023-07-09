using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public Timer timer;
    public static GameManager instance;
    public GameObject generateRandomColorButton;
    public TextMeshProUGUI randomColorText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboChainText;
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;
    public float score;
    public int comboChain;
    public bool blocksClickable;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timer.StartTimer(GameData.instance.gameTimer, OnTimerEnd);

        gameOverPanel.SetActive(false);
    }

    private void OnTimerEnd()
    {
        gameOverPanel.SetActive(true);
    }

    public void PauseTime()
    {
        timer.PauseTimer();
    }

    public void ResumeTime()
    {
        timer.ResumeTimer();
    }

    // Function to disable block clicks
    public void DisableBlockClicks()
    {
        blocksClickable = false;
    }

    // Function to enable block clicks
    public void EnableBlockClicks()
    {
        blocksClickable = true;
    }

    // Function to check if blocks are clickable
    public bool AreBlocksClickable()
    {
        return blocksClickable;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
