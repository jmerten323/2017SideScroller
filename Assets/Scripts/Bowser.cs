using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowser : MonoBehaviour
{
    public float speed;
    public PlayerController player;
    public GameObject impactEffect;
    public float rotationSpeed;
    public int damageToGive;
    private Rigidbody2D myrigidbody2d;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        myrigidbody2d = GetComponent<Rigidbody2D>();

        if(player.transform.position.x < transform.position.x)
        {
            speed = -speed;
            rotationSpeed = -rotationSpeed;
        }
    }

    void Update()
    {
        myrigidbody2d.velocity = new Vector2(speed, myrigidbody2d.velocity.y);
        myrigidbody2d.angularVelocity = rotationSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            HealthManager.HurtPlayer(damageToGive);
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}








