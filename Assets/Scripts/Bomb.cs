using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Weapon {

    public float blastRadius = 4;
    public bool isActive = false;

    void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
       
        if (isActive && player == null)
        {
            Explode();
        }

        }

    public override void Attack()
    {
        transform.parent = null;
        rigidbody2D.velocity = new Vector2(5, 0);
        rigidbody2D.isKinematic = false;
        collider.enabled = true;
    }


    public override void Getpickedup(Player player)
    {
        if (isActive)
        {
            return;
        }
        isActive = true;
        base.Getpickedup(player);
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
