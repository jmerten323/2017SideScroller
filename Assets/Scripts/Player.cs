using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health = 100;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float deadZone = -5;
    public bool canFly = false;
    new Rigidbody2D rigidbody;
    GM _GM;
    private Vector3 startingPosition;

    private Animator anim;
    public bool Air;
    private SpriteRenderer sr;


    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        _GM = FindObjectOfType<GM>();
        startingPosition = transform.position;
        anim = GetComponent<Animator>();
        Air = true;
        sr = GetComponent<SpriteRenderer>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Apply Movement
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 v = rigidbody.velocity;
        v.x = x * speed;

        //runnning animation
        if(v.x != 0)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }

        if (v.x > 0)
            sr.flipX = false;
        else if (v.x < 0)
            sr.flipX = true;

        if (Input.GetButtonDown("Jump")&& (v.y == 0 || canFly))
        {
            v.y = jumpSpeed;
        }
        //jumping animation
        if (Air)
        {
            anim.SetBool("Air", true);
        }
        else
        {
            anim.SetBool("Air", false);
        }

        rigidbody.velocity = v;

        //Check for out
        if(transform.position.y < deadZone)
        {
            GetOut();
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        Air = false;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Air = true;
    }
}
