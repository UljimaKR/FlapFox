using UnityEngine;
using UnityEngine.InputSystem;

public class moveTest2D : MonoBehaviour
{
    Rigidbody playerRb;
    Vector3 forwardForce = new Vector3(0, 0, -2);
    float jumpHeight = 10;
    bool jumpPressed;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        playerRb.AddForce(forwardForce);

        if (jumpPressed)
        {
            Debug.Log("Jumping");
            //playerRb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            playerRb.linearVelocity = Vector3.up * jumpHeight;
            jumpPressed = false;
        }
    }
}