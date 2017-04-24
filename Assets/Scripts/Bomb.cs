using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public float blastRadius = 4;
    public bool isActive = false;

    private new Rigidbody2D rigidbody2D;
    private new Collider2D collider;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isActive)
        {
            Throw();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
        if (player != null && !isActive)
        {
            Getpickedup(player);
        }
        if (isActive && player == null)
        {
            Explode();
        }

        }

    public void Throw()
    {
        transform.parent = null;
        rigidbody2D.velocity = new Vector2(5, 0);
        rigidbody2D.isKinematic = false;
        collider.enabled = true;
    }


    public void Getpickedup(Player player)
    {
        Debug.Log("Getpickedup");
        isActive = true;
        transform.parent = player.transform;
        transform.localScale = new Vector3(.1f, .1f);
        transform.localPosition = new Vector3(.2f, .2f);
        rigidbody2D.velocity = new Vector2();
        rigidbody2D.isKinematic = true;
        collider.enabled = false;
    }
    
        public void Explode()
    {
        var enemies = FindObjectsOfType<Enemy>();
        foreach (var e in enemies)
        {
            if (Vector3.Distance(this.transform.position, e.transform.position) < blastRadius)
            {
                e.gameObject.SetActive(false);
            }
        }
        gameObject.SetActive(false);
    }
}
