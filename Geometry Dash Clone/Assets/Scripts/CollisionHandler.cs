using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleLayermask;

    public UnityEvent OnPlayerDeath;

    private GameManager gameManager;
    private readonly WaitForSeconds restartDelay = new WaitForSeconds(2f);

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if(IsTouchingObstacle())
        {
            OnPlayerDeath.Invoke();
            StartCoroutine(RestartScene());
        }
    }

    private bool IsTouchingObstacle()
    {
        return Physics2D.IsTouchingLayers(gameObject.transform.GetComponent<Collider2D>(), obstacleLayermask);
    }

    IEnumerator RestartScene()
    {
        yield return restartDelay;
        gameManager.StartGame();
    }
}
