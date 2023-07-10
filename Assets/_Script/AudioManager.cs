using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioInstance;

    private AudioSource audioSource;

    public AudioClip cardFlip;
    public AudioClip cardTurn;
    public AudioClip roll;
    public AudioClip cardMatch;
    public AudioClip button;
    public AudioClip gameOver;
    public AudioClip gameClear;

    private void Awake()
    {
        if (audioInstance != null && audioInstance != this)
            Destroy(this);
        else
            audioInstance = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCardFlip()
    {
        audioSource.PlayOneShot(cardFlip);
    }

    public void PlayCardTurn()
    {
        audioSource.PlayOneShot(cardTurn);
    }

    public void PlayRoll()
    {
        audioSource.PlayOneShot(roll);
    }

    public void PlayCardMatch()
    {
        audioSource.PlayOneShot(cardMatch);
    }

    public void PlayButtonSFX()
    {
        audioSource.PlayOneShot(button);
    }

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(gameOver);
    }

    public void PlayGameClear()
    {
        audioSource.PlayOneShot(gameClear);
    }
}
