using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5.0f;
    [SerializeField]
    private Rigidbody2D rb_body;
    [SerializeField]
    private bool facingRight = true;


    // Update is called once per frame

    void Start() {
        rb_body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Move(moveDir);
    }

   void Move(float moveDir)
    {
        rb_body.velocity = (new Vector2(moveDir * movementSpeed, rb_body.velocity.y));
        if (facingRight && moveDir < 0)
            Flip();
        else if (!facingRight && moveDir > 0)
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
