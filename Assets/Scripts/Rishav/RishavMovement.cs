using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RishavMovement : MonoBehaviour
{
    private RishavCollision coll;

    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 10;
    [SerializeField]
    private float wallJumpLerp = 10;
    [SerializeField]
    private float jumpForce = 5;
    public bool wallSlide=false;
    public float slideSpeed = 5;




    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<RishavCollision>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);
        Walk(dir);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (coll.onGround)
                Jump();
        }
        if(coll.onWall && !coll.onGround)
        {
            if (x != 0)
            {
                wallSlide = true;
                WallSlide();
            }
        }
    }

    private void Walk(Vector2 dir)
    {
        rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), wallJumpLerp * Time.deltaTime);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumpForce;
    }

    private void WallSlide()
    {
        bool pushingWall = false;
        if ((rb.velocity.x > 0 && coll.onRightWall) || (rb.velocity.x < 0 && coll.onLeftWall))
        {
            pushingWall = true;
        }
        float push = pushingWall ? 0 : rb.velocity.x;
        rb.velocity = new Vector2(push, -slideSpeed);
    }
}
