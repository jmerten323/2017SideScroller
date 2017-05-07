using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    Player player;
    public float speed = 5;

    void Start()
    {
        player.speed = 5;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!enabled)
        {
            return;
        }
        var player = coll.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.speed = 2;
            Invoke("ResetSpeed", 5.0f);
        }


    }

    void ResetSpeed()
    {
        player.speed = 5;
    }
   

}
    
  

    


