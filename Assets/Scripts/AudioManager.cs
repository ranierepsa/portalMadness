using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip rightPortalClip;
    [SerializeField] AudioClip wrongPortalClip;
    [SerializeField] AudioClip victoryClip;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }

    public void PlayPortalSound(bool isRightPortal)
    {
        if (isRightPortal)
            audioSource.clip = rightPortalClip;
        else
            audioSource.clip = wrongPortalClip;
        audioSource.Play();
    }

    public void PlayVictorySound()
    {
        audioSource.clip = victoryClip;
        audioSource.Play();
    }
}
