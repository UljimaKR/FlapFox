using UnityEngine;

public class SphereFloat : MonoBehaviour
{
    private float maxHeight = 0.5f;
    private float yStart;
    private float yNew;
    private float waveSpeed = 2.0f;

    public float maxRota = 10f;
    private float xNew;
    public float rotaSpeed = 2f;

    void Start()
    {
        yStart = transform.position.y;
    }

    void Update()
    {
        floatWave();
        rotateWave();
    }

    void floatWave()
    {
        yNew = yStart + maxHeight * Mathf.Sin(Time.time * waveSpeed);
        transform.position = new Vector3(transform.position.x, yNew, transform.position.z);
    }

    // Rotate the X axes back and forth to make it look even more floaty!   

    void rotateWave()
    {
        xNew = -maxRota * Mathf.Sin(Time.time * rotaSpeed);
        transform.rotation = Quaternion.Euler(xNew, transform.rotation.y, transform.rotation.z);
    }
}
