using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteChange : MonoBehaviour
{
    [SerializeField] Sprite shipSprite;
    [SerializeField] private SpriteRenderer playerVisualSpriteRenderer;

    public void ChangeToShipSprite()
    {
        playerVisualSpriteRenderer.sprite = shipSprite;
    }
}
