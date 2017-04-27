using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    protected new Rigidbody2D rigidbody2D;
    protected new Collider2D collider;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Attack()
    {

    }

    public virtual void Getpickedup(Player player)
    {
        Debug.Log("Getpickedup");
        transform.parent = player.transform;
        transform.localScale = new Vector3(.1f, .1f);
        transform.localPosition = new Vector3(.2f, .2f);
        rigidbody2D.velocity = new Vector2();
        rigidbody2D.isKinematic = true;
        collider.enabled = false;
    }
}
