using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject generateRandomColorButton;
    public TextMeshProUGUI randomColorText;
    public TextMeshProUGUI scoreText;
    public int score;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        // update score text
        scoreText.text = "Score : " + score.ToString();
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
}
