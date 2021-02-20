using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    [SerializeField] bool isWallJumping = false;
    [SerializeField] bool isWallSliding;
    [SerializeField] float wallSlideSpeed = 0f;
    [SerializeField] float wallJumpForce;
    [SerializeField] Jump_DJump DJump;
    [SerializeField] BasicMovement basic;
    [SerializeField] Rigidbody2D rb;
    public int isLeftOrRight;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        isWallJumping = true;
    }
    void Update() {
        WallSlide();
        WallJumping();
        LeftOrRight();
    }

    void WallSlide()
    {
        if (basic.OnWall && !basic.OnGround && rb.velocity.y<0) 
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
            if((isWallSliding || basic.OnWall) && DJump.canJump && !basic.OnGround)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    rb.velocity = new Vector2(wallJumpForce * isLeftOrRight, DJump.jumpForce);
                }
            }
        }
    }

    void LeftOrRight()
    {
        if (basic.OnRightWall)
            isLeftOrRight = -1;
        else if (basic.OnLeftWall)
            isLeftOrRight = 1;
    }

}
