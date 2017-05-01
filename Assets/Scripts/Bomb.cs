﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Throwable {

    public float blastRadius = 4;
    

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
