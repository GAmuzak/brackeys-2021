using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    
    public Transform playerTransform;
    public LayerMask groundLayer;

    public float teleportDistance = 2.0f;
    public float collisionRadius = 0.25f;
    public float wallSlideSpeed = 0.5f;
    public float jumpForce = 5;
    public float walkSpeed = 10;
    public float wallJumpLerp = 10;
    public Vector2 bottomOffset;
    public Vector2 rightOffset;
    public Vector2 leftOffset;

    private Vector2 moveDir;

    public bool canTeleport = true;
    bool doubleJump;
    bool wallGrab;
    bool wallJumped;
    bool wallSlide;
    bool teleport;
    bool canMove = true;

    public bool OnGround;
    public bool OnWall;
    public bool OnRightWall;
    public bool OnLeftWall;

    public int side = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectCollisions();
        moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Walk(moveDir);
        if(Input.GetButtonDown("Jump"))
        {
            if(OnGround)
            Jump(Vector2.up, false);
        
            if (OnWall && !OnGround)
                WallJump();
        }
        Teleport();

        if (OnGround)
            wallJumped = false;
    }

    private void FixedUpdate()
    {
    }

    void DetectCollisions()
    {
        OnGround    = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
        OnRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer);
        OnLeftWall  = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);
        OnWall = OnRightWall || OnLeftWall;
    }


    

    void Teleport()
    {
        if (canTeleport)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //if (rb.velocity.x > 0)
                playerTransform.position = new Vector2(playerTransform.position.x + teleportDistance, playerTransform.position.y);
                //else playerTransform.position = new Vector2(playerTransform.position.x - teleportDistance, playerTransform.position.y);
            }
        }
    }

    void WallJump()
    {
        if(OnWall)
        {
            rb.velocity = new Vector2(transform.position.x, -wallSlideSpeed);
        }

        Vector2 wallDir = OnRightWall ? Vector2.left : Vector2.right;
        Jump((Vector2.up + wallDir), true);
        wallJumped = true;
    }

    
    void Jump(Vector2 dir, bool wall)
    {
        //rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.velocity += dir * jumpForce;
    }

    void WallSlide()
    {

    }

    void Walk(Vector2 moveDir)
    {
        if (!canMove)
            return;
        if(!wallJumped)
            rb.velocity = new Vector2(moveDir.x * walkSpeed, rb.velocity.y);
        else
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(moveDir.x*walkSpeed, rb.velocity.y)), wallJumpLerp * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset, rightOffset, leftOffset };

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
    }

    //IEnumerator disableMove(float time)
    //{
    //    canMove = false;
    //    yield return waitfor
    //}
}
