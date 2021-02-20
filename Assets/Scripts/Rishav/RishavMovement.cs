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
    [SerializeField]
    private float slideSpeed = 200f;

    public bool wallJumped=false;
    public bool canMove=true;




    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<RishavCollision>();
        Debug.Log(Time.deltaTime);
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
                Jump(Vector2.up);
            if (coll.onWall && !coll.onGround)
                WallJump();
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


    private void WallJump()
    {
        StopCoroutine(DisableMovement(0));
        StartCoroutine(DisableMovement(.5f));

        Vector2 wallDir = coll.onRightWall ? Vector2.left : Vector2.right;

        Jump((Vector2.up + wallDir / 1.5f));

        wallJumped = true;
    }
    private void Walk(Vector2 dir)
    {
        if (!canMove)
            return;

        if (!wallJumped)
        {
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), wallJumpLerp * Time.deltaTime);
        }
    }

    private void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;
    }

    private void WallSlide()
    {
        bool pushingWall = false;
        if ((rb.velocity.x > 0 && coll.onRightWall) || (rb.velocity.x < 0 && coll.onLeftWall))
        {
            pushingWall = true;
        }
        float push = pushingWall ? rb.velocity.x:0;
        rb.velocity = new Vector2(push, -slideSpeed*Time.deltaTime);
    }

    IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }
} 
