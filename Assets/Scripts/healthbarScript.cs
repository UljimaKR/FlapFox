using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class healthbarScript : MonoBehaviour
{
    public gameplay2D playerScript2D;
    public Slider healthbar;
    private float health;

    void Start()
    {
        playerScript2D = GameObject.FindWithTag("Player").GetComponent<gameplay2D>();
    }

    void Update()
    {
        health = playerScript2D.health;
        healthbar.value = health;
    }
}
