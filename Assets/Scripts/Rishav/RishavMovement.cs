using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private float slideSpeed = 4;

    [SerializeField]
    PlayerAnim animControl;
    public Transform playerTransform;
    public float teleportDistance = 2.0f;
    public int side = 1;
    private bool wallJumped = false;


    public bool canWallJump = false;
    public bool canMove=true;
    public bool canTeleport=true;
    public bool canDoubleJump = false;
    public int extraJumps = 0;



    // Start is called before the first frame update
    void Start()
    {
        if (canDoubleJump)
            extraJumps = 1;
        else extraJumps = 0;
        coll = GetComponent<RishavCollision>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);
        Walk(dir);

        if(coll.onWall)
        {
            if (side != coll.wallSide)
                animControl.Flip(side * -1);

        }
        animControl.setAxes(x, y, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (coll.onGround)
                Jump(Vector2.up);
            else if (extraJumps > 0)
            {
                Jump(Vector2.up);
                extraJumps = 0;
            }
            if (coll.onWall && !coll.onGround && canWallJump)
                WallJump();

        }
        if (coll.onGround && canDoubleJump)
        {
            extraJumps = 1;
        }
        if(coll.onWall && !coll.onGround)
        {
            if (x != 0)
            {
                wallSlide = true;
                WallSlide();
            }
        }
        if (!coll.onWall)
            wallSlide = false;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            TeleportPlayer();
        }

        if (x > 0)
        {
            side = 1;
            animControl.Flip(side);
        }
        if (x < 0)
        {
            side = -1;
            animControl.Flip(side);
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
        
        rb.velocity = new Vector2(rb.velocity.x, -slideSpeed);
        wallSlide = true;
    }

    IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    IEnumerator DisableTeleport(float time)
    {
        canTeleport = false;
        yield return new WaitForSeconds(time);
        canTeleport = true;
    }

    void TeleportPlayer() 
    {
        if (canTeleport)
        {
            StopCoroutine(DisableTeleport(0));
            StartCoroutine(DisableTeleport(.5f));

            if (side>0) 
                    playerTransform.position = new Vector2(playerTransform.position.x + teleportDistance, playerTransform.position.y);
                else 
                    playerTransform.position = new Vector2(playerTransform.position.x - teleportDistance, playerTransform.position.y);
            
        }
    }
} 
