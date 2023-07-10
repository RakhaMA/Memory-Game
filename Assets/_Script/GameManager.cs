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
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI comboChainText;
    public TextMeshProUGUI timerText;
    public GameObject gameplayPanel;
    public GameObject gameOverPanel;
    public GameObject gameClearPanel;
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
        gameplayPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        gameClearPanel.SetActive(false);
    }

    private void OnTimerEnd()
    {
        AudioManager.audioInstance.PlayGameOver();
        gameplayPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void GameClear()
    {
        AudioManager.audioInstance.PlayGameClear();
        gameplayPanel.SetActive(false);
        gameClearPanel.SetActive(true);

        //save the highscore to playerprefs
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (score > PlayerPrefs.GetFloat("HighScore"))
            {
                PlayerPrefs.SetFloat("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }

        //display the highscore
        highScoreText.text = "HighScore\n " + PlayerPrefs.GetFloat("HighScore").ToString();
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
