using UnityEngine;

public class SphereFloat : MonoBehaviour
{
    private float interval = 2f;
    private float force = 15;
    Rigidbody sphereRb;

    void Start()
    {
        sphereRb = GetComponent<Rigidbody>();
    }

    // Add Target height and minimum height, apply impulse upward on minimum height and maybe impulse downward on maximum height to ensure that the sphere stays in boundaries

    void FixedUpdate()
    {
        Debug.Log(interval);
        interval -= Time.fixedDeltaTime;
        if (interval <= 0)
        {
            sphereRb.AddForce(Vector3.up * force, ForceMode.Impulse);
            interval = 1;
        }
    }
}
