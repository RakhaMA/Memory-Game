using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomColor : MonoBehaviour
{
    public GameObject blockPrefab; // Prefab for the block object
    public Vector3 offset = new Vector3(-1f, -1.5f, 0f); // create offset for first row
    public BlockColorType[] colors; // Array to hold the different colors
    public int numberOfBlocks = 18; // Total number of blocks to instantiate
    public int scorePoint = 10; // Score point for each correct color match

    [SerializeField] private List<GameObject> blocksList = new List<GameObject>(); // List to hold the instantiated blocks
    [SerializeField] private List<BlockColorType> blockColorsList = new List<BlockColorType>();// List to track the colors of the blocks
    [SerializeField] private BlockColorType generatedColor; // Temp variable to save generated random color

    // Start is called before the first frame update
    void Start()
    {
        GenerateBlocks();
        GetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateBlocks()
    {
        // Instantiate the blocks
        for (int i = 0; i < numberOfBlocks; i++)
        {
            GameObject block = Instantiate(blockPrefab, transform.position, Quaternion.identity);
            blocksList.Add(block);
        }

        // Shuffle the colors array
        ShuffleArray(colors);

        // Assign colors to the blocks
        AssignColorsToBlocks();

        // Randomly position the blocks
        PlaceBlocks();
    }

    void ShuffleArray<T>(T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = Random.Range(0, n);
            n--;
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }

    void AssignColorsToBlocks()
    {
        for (int i = 0; i < blocksList.Count; i++)
        {
            BlockColorType blockColor = colors[i % colors.Length]; // Get the color from the shuffled array
            blocksList[i].GetComponent<BlockColor>().SetBlockColor(blockColor);

            blockColorsList.Add(blockColor); // Add the color to the list
        }
    }

    void PlaceBlocks()
    {
        List<Vector3> availablePositions = new List<Vector3>(); // List to hold available positions for blocks

        float xOffset = 2f; // Distance between blocks on the x-axis
        float yOffset = 2f; // Distance between blocks on the y-axis

        

        // Create a list of all possible positions
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 6; column++)
            {
                Vector3 blockPosition = new Vector3(column * xOffset, row * yOffset, 0f) + offset;
                availablePositions.Add(blockPosition);
            }
        }

        // Assign positions to the blocks randomly
        for (int i = 0; i < blocksList.Count; i++)
        {
            int randomIndex = Random.Range(0, availablePositions.Count);
            Vector3 blockPosition = availablePositions[randomIndex];
            blocksList[i].transform.position = blockPosition;
            availablePositions.RemoveAt(randomIndex);
        }
    }

    public void GetRandomColorButton()
    {
        GetRandomColor();
    }

    public BlockColorType GetRandomColor()
    {
        int randomIndex = Random.Range(0, colors.Length);
        // check if color still available
        if(blockColorsList.Contains(colors[randomIndex]) && blockColorsList.Count > 0)
        {
            // color still available, get another color
            generatedColor = colors[randomIndex];
            GameManager.instance.randomColorText.text = generatedColor.ToString();
            GameManager.instance.EnableBlockClicks();
            GameManager.instance.generateRandomColorButton.SetActive(false);
            return generatedColor;
        }else
        {
            // color not available, get another color
            return GetRandomColor();
        }
    }

    public void CheckColorMatch(GameObject clickedBlock)
    {
        BlockColor clickedBlockColor = clickedBlock.GetComponent<BlockColor>(); // Get the BlockColor component of the clicked block

        if (clickedBlockColor.GetBlockColor() == generatedColor) // Check if the colors match
        {
            // Colors match, do something (e.g., increase score, destroy the block, etc.)
            Debug.Log("Color matched!");
            // Increase combo chain
            GameManager.instance.comboChain += 1;
            if(GameManager.instance.comboChain > 1)
            {
                GameManager.instance.comboChainText.gameObject.SetActive(true);
            }else{
                GameManager.instance.comboChainText.gameObject.SetActive(false);
            }
            GameManager.instance.comboChainText.text = "Combo : x " + GameManager.instance.comboChain.ToString();
            // Add score based on combo chain
            AddScore(GameManager.instance.comboChain);
            // Destroy the block
            Destroy(clickedBlock);
            blocksList.Remove(clickedBlock);
            blockColorsList.Remove(generatedColor);
        }
        else
        {
            // Colors don't match, do something else (e.g., display a message, play a sound, etc.)
            Debug.Log("Color not matched!");
            GameManager.instance.comboChain = 0;
        }
    }

    public void AddScore(int comboChain)
    {
        int score = scorePoint * comboChain;
        GameManager.instance.score += score;
        GameManager.instance.scoreText.text = "Score: " + GameManager.instance.score.ToString();
    }
}
