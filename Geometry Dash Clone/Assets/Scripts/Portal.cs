using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerSpriteChange playerSpriteChange;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerMovement = other.GetComponent<PlayerMovement>();
            playerSpriteChange = other.GetComponent<PlayerSpriteChange>();
            playerMovement.gameMode = GameMode.Ship;
            playerSpriteChange.ChangeToShipSprite();
        }
    }
}
