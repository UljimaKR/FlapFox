using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class moveTest2D : MonoBehaviour
{
    private float health;
    private float armor;


    private Rigidbody playerRb;
    private Vector3 forwardForce = new Vector3(0, 0, -2);
    private float jumpHeight = 10;
    private float bouncingTimer = 0.2f;
    private bool jumpPressed;
    private Quaternion bounce = Quaternion.Euler(-5, 180, 0); // -5 is the bounce upwards, 180 is player base position
    private Quaternion startRotation; // Could probably just put (0, 180, 0) instead but at least some code gotta be clean


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        startRotation = transform.rotation;

        // JUST FOR TESTING
        health = 100f;
    }


    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // True bool allows movement in FixedUpdate, coroutine for bounce effect
            jumpPressed = true;
            StartCoroutine(JumpRotation());
        }
    }

    IEnumerator JumpRotation()
    {
        // Rotate to one position, then back to create a bouncing effect
        transform.rotation = bounce;
        yield return new WaitForSeconds(bouncingTimer);
        transform.rotation = startRotation;
    }


    void FixedUpdate()
    {
        // Player continuously flies forward
        playerRb.AddForce(forwardForce);

        if (jumpPressed)
        {
            // Safe velocity on x and z axis, then add jumpHeight to the y-axis and reset jump var
            Vector3 jumpVelocity = playerRb.linearVelocity;
            jumpVelocity.y = jumpHeight;
            playerRb.linearVelocity = (jumpVelocity);
            jumpPressed = false;
        }
    }


    public void receiveDamage(float x)
    {
        health -= x;
        Debug.Log("I have " + health + "HP left!");

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

/* TO DO:
 * 
 * -Maybe share a linearVelocity between the forward movement and jumping to stop the vehicle from slowing down
 * 
 * -preserve variables during rotation instead of randomly assigning 180
 * 
*/