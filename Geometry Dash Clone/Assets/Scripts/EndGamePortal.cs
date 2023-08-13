using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndGamePortal : MonoBehaviour
{
    public UnityEvent OnPlayerWin;

    private bool winEventTriggered = false;
    private GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!winEventTriggered)
            {
                OnPlayerWin.Invoke();
                gameManager = FindObjectOfType<GameManager>();
                gameManager.GetComponentInChildren<Canvas>().enabled = true;
                
                winEventTriggered = true;
            }
        }
    }

}
