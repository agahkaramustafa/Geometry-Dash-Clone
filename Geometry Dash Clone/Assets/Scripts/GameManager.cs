using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    private void Awake()
    {
        // Singleton pattern to ensure there is only one GameManager in the game at any given time
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void StartGame()
    {
        // Load the game scene when the start button is pressed in the main menu scene
        int gameSceneIndex = 1;
        SceneManager.LoadScene(gameSceneIndex);
    }
}
