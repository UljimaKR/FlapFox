using UnityEngine;

public class softObject : MonoBehaviour
{
    private Rigidbody playerRb;
    private float damage = 20f;

    public GameObject player;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            player.GetComponent<gameplay2D>().receiveDamage(damage);
        }
    }
}
