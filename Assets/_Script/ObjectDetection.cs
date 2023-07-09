using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDetection : MonoBehaviour
{
    private GenerateRandomColor generateRandomColor;
    private BlockColor blockColor;

    private void Start()
    {
        generateRandomColor = FindObjectOfType<GenerateRandomColor>();
        blockColor = GetComponent<BlockColor>();
    }

    private void OnMouseDown()
    {
        if (!GameManager.instance.AreBlocksClickable())
        {
            return;
        }
        GameManager.instance.DisableBlockClicks();
        
        Debug.Log("Clicked on " + gameObject.name);
        StartCoroutine(ShowColorForDuration());
    }

    private IEnumerator ShowColorForDuration()
    {
        blockColor.ShowBlockColor(); // Show the block color
        GameManager.instance.PauseTime(); // Pause the timer

        yield return new WaitForSeconds(2f);
        
        generateRandomColor.CheckColorMatch(gameObject); // Check if the block color matches the generated color
        blockColor.HideBlockColor(); // Hide the block color after 2 seconds
        GameManager.instance.generateRandomColorButton.SetActive(true); // Show the generate random color button
        GameManager.instance.ResumeTime(); // Resume the timer
    }
}