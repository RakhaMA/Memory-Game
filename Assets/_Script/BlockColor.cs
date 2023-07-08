using UnityEngine;

public enum BlockColorType
{
    Red,
    Green,
    Blue,
    Yellow,
    Black,
    Purple
}

public class BlockColor : MonoBehaviour
{
    private BlockColorType blockColor;
    private Color originalColor;
    public Sprite baseSprite;
    public Sprite showSprite;
    public Sprite[] blocksSprites;

    private void Start()
    {
        originalColor = Color.white; // Store the original color of the block
    }

    public void SetBlockColor(BlockColorType color)
    {
        blockColor = color;
        //GetComponent<SpriteRenderer>().color = GetColorFromType(blockColor); // Apply the color to the block's sprite renderer

        // Set the appropriate sprite based on the color type
        // int spriteIndex = (int)color; // Assuming the sprite array is ordered to match the BlockColorType enum
        // GetComponent<SpriteRenderer>().sprite = blocksSprites[spriteIndex];
    }

    public BlockColorType GetBlockColor()
    {
        return blockColor;
    }

    public void ShowBlockColor()
    {
        //GetComponent<SpriteRenderer>().color = GetColorFromType(blockColor); // Show the color of the block
        // hide the sprite
        //GetComponent<SpriteRenderer>().sprite = baseSprite;

        // Set the sprite based on the color type
        int spriteIndex = (int)blockColor;
        if (spriteIndex >= 0 && spriteIndex < blocksSprites.Length)
        {
            GetComponent<SpriteRenderer>().sprite = blocksSprites[spriteIndex];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = baseSprite;
        }
    }

    public void HideBlockColor()
    {
        GetComponent<SpriteRenderer>().color = originalColor; // Hide the color of the block by restoring the original color
        // show the sprite
        GetComponent<SpriteRenderer>().sprite = showSprite;
    }

    private Color GetColorFromType(BlockColorType colorType)
    {
        switch (colorType)
        {
            case BlockColorType.Red:
                return Color.red;
            case BlockColorType.Green:
                return Color.green;
            case BlockColorType.Blue:
                return Color.blue;
            case BlockColorType.Yellow:
                return Color.yellow;
            case BlockColorType.Black:
                return Color.black;
            case BlockColorType.Purple:
                return Color.magenta;
            default:
                return Color.white;
        }
    }
}
