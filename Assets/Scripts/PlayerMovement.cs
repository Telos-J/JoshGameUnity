using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public Vector2 movement;
    public TilemapRenderer doorSprite;
    public TilemapCollider2D doorCollider;
    public PlayerState initialState;

    private void Start() {
        transform.position = initialState.position;
    }

    // Update is called once per frame
    // However your framerate can constantly change
    private void Update()
    {
        movement.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.Normalize();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleDoor();
        }
    }

    // Fixed Update is executed by a fixed timer.
    // By default, 50 times per second.
    private void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * maxSpeed * Time.fixedDeltaTime);

        if (movement.sqrMagnitude != 0f)
        {
            animator.SetFloat("PrevHorizontal", movement.x);
            animator.SetFloat("PrevVertical", movement.y);
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void ToggleDoor()
    {
        doorSprite.enabled = !doorSprite.enabled;
        doorCollider.enabled = !doorCollider.enabled;
    }
}
