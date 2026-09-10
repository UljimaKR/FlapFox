using UnityEngine;

public class hardObject : MonoBehaviour
{
    private Rigidbody playerRb;
    private float damage = 50f;

    public GameObject player;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerRb = other.gameObject.GetComponent<Rigidbody>();

            // how much the character should be knocked back
            var pushback = 200;

            // calculate force (direction) vector -> player position - position of object will point to the player
            Vector3 force = other.transform.position - transform.position;

            // normalize force vector to get direction only and trim magnitude
            force.Normalize();

            playerRb.AddForce(force * pushback);



            player = other.gameObject;
            player.GetComponent<gameplay2D>().receiveDamage(damage);
        }
    }
}

// Credit to kingcoyote at https://discussions.unity.com/t/push-object-in-opposite-direction-of-collision/153430/2