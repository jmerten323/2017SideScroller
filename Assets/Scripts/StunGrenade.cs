using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGrenade : Throwable
{

    public float blastRadius = 4;


    void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();

        if (isActive && player == null)
        {
            Explode();
        }

    }
    public void Explode()
    {
        var enemies = FindObjectsOfType<Enemy>();
        foreach (var e in enemies)
        {
            if (Vector3.Distance(this.transform.position, e.transform.position) < blastRadius)
            {
                StartCoroutine(Stun(e));
            }
        }
        collider.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator Stun(Enemy e)
    {
        var renderer = e.GetComponent<SpriteRenderer>();

        e.enabled = false;
        renderer.color = new Color(1, 1, 1, .4f);
        yield return new WaitForSeconds(5);

        e.enabled = true;
        renderer.color = new Color(1, 1, 1, 1);
    }

}

