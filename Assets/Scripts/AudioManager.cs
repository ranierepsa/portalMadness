using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip rightPortalClip;
    [SerializeField] AudioClip wrongPortalClip;
    [SerializeField] AudioClip victoryClip;
    [SerializeField] PortalTriggeredEvent portalTriggeredEvent;
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

    private void PlayPortalSound(Vector2 destLocation, bool isPath)
    {
        PlayPortalSound(isPath);
    }

    public void PlayVictorySound()
    {
        audioSource.clip = victoryClip;
        audioSource.Play();
    }

    private void OnEnable()
    {
        portalTriggeredEvent?.Subscribe(PlayPortalSound);
    }

    private void OnDisable()
    {
        portalTriggeredEvent?.Unsubscribe(PlayPortalSound);
    }
}
