using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Reference components
    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    [SerializeField] float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to components
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        bool isMovingRight = Input.GetKey(KeyCode.RightArrow);
        bool isMovingLeft = Input.GetKey(KeyCode.LeftArrow);
        bool isMovingUp = Input.GetKey(KeyCode.UpArrow);
        bool isMovingDown = Input.GetKey(KeyCode.DownArrow);

        // Handle movement animations and physics-based movement
        Vector2 movement = Vector2.zero;
        if (isMovingRight)
        {
            movement = Vector2.right;
            animator.SetBool("Right", true);
        }
        else
        {
            animator.SetBool("Right", false);
        }

        if (isMovingLeft)
        {
            movement = Vector2.left;
            animator.SetBool("Left", true);
        }
        else
        {
            animator.SetBool("Left", false);
        }

        // Set animator parameters for vertical movement
        if (isMovingUp)
        {
            movement = Vector2.up;
            animator.SetBool("Up", true);
        }
        else
        {
            animator.SetBool("Up", false);
        }

        if (isMovingDown)
        {
            movement = Vector2.down;
            animator.SetBool("Down", true);
        }
        else
        {
            animator.SetBool("Down", false);
        }

        // Apply movement velocity to Rigidbody2D
        rb.velocity = movement * speed;
    }
}
