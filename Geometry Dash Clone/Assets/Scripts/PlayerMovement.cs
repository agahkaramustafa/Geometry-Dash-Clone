using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private Transform leftSide;
    [SerializeField] private Transform rightSide;
    [SerializeField] private LayerMask groundLayermask;
    [SerializeField] private Transform sprite;

    private Rigidbody2D rb;
    private bool isRotationCorrected = false;

    private readonly float groundDetectionDistance = 0.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // MoveRight();

        if (OnGroundLeftSide() || OnGroundRightSide())
        {
            if (!isRotationCorrected)
            {
                CorrectSpriteRotation();
                //isRotationCorrected = true;
            }

            if (Input.GetMouseButtonDown(0))
            {
                Jump();
                //isRotationCorrected = false;
            }
        }
        else
        {
            sprite.Rotate(rotateSpeed * Time.deltaTime * Vector3.back);
        }

    }

    private void MoveRight()
    {
        // Adds the movement speed to the rigidbody's position. This moves the player right.
        transform.position += movementSpeed * Time.deltaTime * Vector3.right;
    }

    private void CorrectSpriteRotation()
    {
        // Rotate the sprite to align its rotation with the ground.
        Vector3 rotation = sprite.rotation.eulerAngles;
        rotation.z = Mathf.Round(rotation.z / 90) * 90;
        sprite.rotation = Quaternion.Euler(rotation);
    }

    private void Jump()
    {
        // Sets the velocity to zero and adds the jump force to the RigidBody.
        rb.velocity = Vector2.zero;
        rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
    }

    private bool OnGroundLeftSide()
    {
        // Returns true if there is a hit false otherwise. This is used to detect collisions.
        RaycastHit2D hit = Physics2D.Raycast(leftSide.position, Vector2.down, groundDetectionDistance, groundLayermask);
        return hit.collider != null;
    }

    private bool OnGroundRightSide()
    {
        // Returns true if there is a hit false otherwise. This is used to detect collisions.
        RaycastHit2D hit = Physics2D.Raycast(rightSide.position, Vector2.down, groundDetectionDistance, groundLayermask);
        return hit.collider != null;
    }
}
