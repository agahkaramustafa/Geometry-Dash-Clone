using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameMode
{
    Cube = 0,
    Ship = 1
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private Transform leftSide;
    [SerializeField] private Transform rightSide;
    [SerializeField] private LayerMask groundLayermask;
    [SerializeField] private Transform sprite;

    public GameMode gameMode = GameMode.Cube;

    public bool IsOnGround { get { return IsOnGroundLeftSide() || IsOnGroundRightSide(); } }

    private Rigidbody2D rb;
    private bool isRotationCorrected = false;

    private readonly float groundDetectionDistance = 0.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveRight();

        Invoke(gameMode.ToString(), 0);
    }

    private void Cube()
    {
        if (IsOnGroundLeftSide() || IsOnGroundRightSide())
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

    private void Ship()
    {
        sprite.rotation = Quaternion.Euler(0, 0, rb.velocity.y);

        if (Input.GetMouseButton(0) && rb.gravityScale > 0)
        {
            rb.gravityScale = -rb.gravityScale;
        }
        else if(!Input.GetMouseButton(0) && rb.gravityScale < 0)
        {
            rb.gravityScale = Mathf.Abs(rb.gravityScale);
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

    private bool IsOnGroundLeftSide()
    {
        // Returns true if there is a hit false otherwise. This is used to detect collisions.
        RaycastHit2D hit = Physics2D.Raycast(leftSide.position, Vector2.down, groundDetectionDistance, groundLayermask);
        return hit.collider != null;
    }

    private bool IsOnGroundRightSide()
    {
        // Returns true if there is a hit false otherwise. This is used to detect collisions.
        RaycastHit2D hit = Physics2D.Raycast(rightSide.position, Vector2.down, groundDetectionDistance, groundLayermask);
        return hit.collider != null;
    }


}
