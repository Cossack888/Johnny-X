using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CustomJump : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Collider2D playerCollider;
    public float moveSpeed = 10f;
    public float jumpPower = 50f;
    public float maxRunSpeed = 5f;
    public float standingContactDistance = 0.1f;
    public bool velocityCapEnabled = true;

    public void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (playerRigidbody != null)
        {
            ApplyInput();

            if (velocityCapEnabled)
            {
                CapVelocity();
            }
        }
        else
        {
            Debug.LogWarning("Rigid body not attached to player " + gameObject.name);
        }
    }

    /// <summary>
    /// Check to see if any player keys are down, and if so... perform relevant actions
    /// </summary>
    public void ApplyInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        // Left and Right
        float xForce = xInput * moveSpeed * Time.deltaTime;
        float yForce = 0;

        // Jumping
        if (yInput > 0)
        {
            if (IsOnTopOfCollider() && playerRigidbody.velocity.y == 0)
            {
                // Allow character to jump
                yForce = jumpPower;
            }
        }

        Vector2 force = new Vector2(xForce, yForce);

        playerRigidbody.AddForce(force, ForceMode2D.Impulse);

        Debug.Log("xForce: " + xForce);
        // Debug.Log("Velocity: " + playerRigidbody.velocity.x + " " + playerRigidbody.velocity.y);
    }

    public void CapVelocity()
    {
        float cappedXVelocity = Mathf.Min(Mathf.Abs(playerRigidbody.velocity.x), maxRunSpeed) * Mathf.Sign(playerRigidbody.velocity.x);
        float cappedYVelocity = playerRigidbody.velocity.y;

        playerRigidbody.velocity = new Vector3(cappedXVelocity, cappedYVelocity);
    }

    /// <summary>
    /// Checks if there are any non-trigger colliders that are below the player
    /// </summary>
    /// <returns></returns>
    public bool IsOnTopOfCollider()
    {
        // Check colliders
        if (playerCollider)
        {
            ContactFilter2D filter2D = new ContactFilter2D();
            filter2D.useTriggers = false;

            RaycastHit2D[] results = new RaycastHit2D[10];

            // playerCollider.OverlapCollider(filter2D, results);
            playerCollider.Cast(new Vector2(0, -1), filter2D, results, standingContactDistance);

            foreach (RaycastHit2D hit in results)
            {
                // Check if character is on top of collider
                if (hit.collider && hit.collider.transform.position.z == playerCollider.transform.position.z)
                {
                    // Colliding
                    return true;
                }
            }
        }

        return false;
    }
}