using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public Rigidbody2D rb_body;
    public bool facingRight = true;
    public float movement;

    // Update is called once per frame

    void Start() {
        rb_body = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        movement = Input.GetAxis("Horizontal");
        rb_body.velocity = new Vector2(movement * movementSpeed, rb_body.velocity.y);
        if (facingRight && movement<0)
            Flip();
        else if (!facingRight && movement>0)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x = -1;
        transform.localScale = Scaler;
    }
}
