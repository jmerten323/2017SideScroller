using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : Weapon {

    public bool isActive = false;

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
}
