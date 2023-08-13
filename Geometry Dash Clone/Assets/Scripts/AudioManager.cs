using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        int numAudioManagers = FindObjectsOfType<AudioManager>().Length;

        // Singleton pattern to ensure there is only one GameManager in the game at any given time
        if (numAudioManagers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.volume != PlayerPrefs.GetFloat("volume"))
        {
            audioSource.volume = PlayerPrefs.GetFloat("volume");
        }
    }
}
