using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlayed;
    public void AudioPlay()
    {
        audioSource = GetComponent<AudioSource>();
        if (!isPlayed)
        {
            audioSource.Play();
            DontDestroyOnLoad(transform.gameObject);
            isPlayed = true;
        }
    }
}
