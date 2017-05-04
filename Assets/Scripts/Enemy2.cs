﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    float timeStarted = 0;
    public float lastforSeconds = 5;
    Player player;


    void OnCollisionEnter2D(Collision2D coll)
    {

        var player = coll.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.speed = 2;
            timeStarted = Time.time;


        }


    }

    void Update()
    {
        if (timeStarted != 0 && timeStarted + lastforSeconds < Time.time)
        {
            Debug.Log("speedingup");
            timeStarted = 0;
            player.speed = 5;


        }
    }
}
