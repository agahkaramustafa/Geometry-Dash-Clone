using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleLayermask;
    [SerializeField] private LayerMask groundLayermask;

    public UnityEvent OnPlayerDeath;

    private GameManager gameManager;
    private bool deathEventTriggered = false;

    private readonly float groundDetectionDistance = 0.6f;
    private readonly WaitForSeconds restartDelay = new WaitForSeconds(2f);

    private void Update()
    {
        if(IsTouchingObstacle() || IsTouchingHorizontal())
        {
            if (!deathEventTriggered)
            {
                OnPlayerDeath.Invoke();
                deathEventTriggered = true;
                StartCoroutine(RestartScene());
            }
        }
    }

    private bool IsTouchingObstacle()
    {
        return Physics2D.IsTouchingLayers(gameObject.transform.GetComponent<Collider2D>(), obstacleLayermask);
    }

    private bool IsTouchingHorizontal()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, groundDetectionDistance, groundLayermask);
        return hit.collider != null;
    }

    IEnumerator RestartScene()
    {
        yield return restartDelay;
        FindObjectOfType<GameManager>().StartGame();
    }
}
