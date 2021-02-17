using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    [SerializeField] bool isWallJumping = false;
    [SerializeField] float wallSlideSpeed = 0f;
    [SerializeField] Jump_DJump DJump;
    [SerializeField] BasicMovement basic;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] Vector2 wallCheckSize;
    [SerializeField] Transform side;
    [SerializeField] bool isTouchingWall;
    [SerializeField] Rigidbody2D rb_body;
    [SerializeField] bool isWallSliding;
    [SerializeField] float wallJumpForce;
    [SerializeField] Vector2 wallJumpAngle;

    private void Start() {
        rb_body = GetComponent<Rigidbody2D>();
        wallJumpAngle.Normalize();
        isWallJumping = true;
    }
    void Update() {
        CheckWall();
        WallSlide();
        WallJumping();
    }
    void CheckWall()
    {
        isTouchingWall = Physics2D.OverlapCircle(side.position, 0.1f, wallLayer);
    }

    void WallSlide()
    {
        if (isTouchingWall && !DJump.isGrounded && rb_body.velocity.y<0) 
        {
            isWallSliding = true;
        }

        else{
            isWallSliding = false;
        }

        if (isWallSliding)
        {
            rb_body.velocity = new Vector2 (rb_body.velocity.x, -wallSlideSpeed);
        }

    }

    void WallJumping()
    {
        if (isWallJumping)
        {
            if((isWallSliding || isTouchingWall) && DJump.canJump)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    rb_body.AddForce(new Vector2(wallJumpForce * -basic.wallJumpDirection * wallJumpAngle.x, wallJumpForce * wallJumpAngle.y), ForceMode2D.Impulse);
                }
            }
        }
    }
}
