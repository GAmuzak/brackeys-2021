using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    [SerializeField] bool isWallJumping = false;
    [SerializeField] bool isWallSliding;
    [SerializeField] bool isTouchingWall;
    [SerializeField] float wallSlideSpeed = 0f;
    [SerializeField] float wallJumpForce;
    [SerializeField] Jump_DJump DJump;
    [SerializeField] BasicMovement basic;
    [SerializeField] Vector2 wallJumpAngle;
    [SerializeField] Vector2 wallCheckSize;
    [SerializeField] Transform side;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        wallJumpAngle.Normalize();
        isWallJumping = true;
    }
    void Update() {
        WallSlide();
        WallJumping();
    }
    void WallSlide()
    {
        if (isTouchingWall && !basic.OnGround && rb.velocity.y<0) 
        {
            isWallSliding = true;
        }

        else{
            isWallSliding = false;
        }

        if (isWallSliding)
        {
            rb.velocity = new Vector2 (rb.velocity.x, -wallSlideSpeed);
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
                    rb.AddForce(new Vector2(wallJumpForce * -basic.wallJumpDirection * wallJumpAngle.x, wallJumpForce * wallJumpAngle.y), ForceMode2D.Impulse);
                }
            }
        }
    }

}
