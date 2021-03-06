﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health = 100;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float deadZone = -5;
    public float pipeZone = -4.5f;
    public bool canFly = false;
    public bool changeSpeed = false;
    public Weapon currentWeapon;
    new Rigidbody2D rigidbody;
    GM _GM;
    private Vector3 startingPosition;
    private GameObject coll;

    private List<Weapon> weapons = new List<Weapon>();

    private Animator anim;
    public bool Air;
    private SpriteRenderer sr;


    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        _GM = FindObjectOfType<GM>();
        startingPosition = transform.position;
        anim = GetComponent<Animator>();
        Air = true;
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Apply Movement
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 v = rigidbody.velocity;
        v.x = x * speed;

        //runnning animation
        if (v.x != 0)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
        if (v.x > 0)
        {
            sr.flipX = false;
        }
        else if (v.x < 0)
        {
            sr.flipX = true;
        }

        if (Input.GetButtonDown("Jump") && (v.y == 0 || canFly))
        {
            v.y = jumpSpeed;
        }
        //jumping animation
        if (v.y != 0)
        {
            anim.SetBool("Air", true);
        }
        else
        {
            anim.SetBool("Air", false);
        }

        rigidbody.velocity = v;

        //Attack with a weapon if you have one
        if (Input.GetButtonDown("Fire1") && currentWeapon != null)
        {
            currentWeapon.Attack();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            int i = (weapons.IndexOf(currentWeapon) + 1) % weapons.Count;
            SetCurrentWeapon(weapons[i]);
        }


        //Check for out
        if (transform.position.y < deadZone)
        {
            GetOut();
        }

        if (transform.position.y < pipeZone)
        {
            transform.position = new Vector3(-4.953446f,3.010493f, 0);
        }


        //rigidbody.AddForce(new Vector2(x * speed, 0));

    }

    public void GetOut()
    {
        _GM.SetLives(_GM.GetLives() - 1);
        transform.position = startingPosition;
        Debug.Log("You're Out");
    }

    public void PowerUp1()
    {
        anim.SetTrigger("Powered");
    }

    public void AddWeapon(Weapon w)
    {
        weapons.Add(w);
        SetCurrentWeapon(w);
    }

    public void SetCurrentWeapon(Weapon w)
    {
        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(false);
        }
        currentWeapon = w;

        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(true);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Air = false;
        var weapon = collision.gameObject.GetComponent<Weapon>();
        if (weapon != null)
        {
            weapon.Getpickedup(this);

        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Air = true;
        if (collision.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }
     
   
}

    


    
  
