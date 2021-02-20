using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_DJump : MonoBehaviour
{
    public GameObject player = null;

    public float jumpForce = 5.0f;
    public int extraJumps = 0;
    public bool canJump;
    public bool canDJump = false;

    [SerializeField] BasicMovement basic;
    [SerializeField] LayerMask enemyMask;
    [SerializeField] Rigidbody2D rb;

    int jumpCount = 0;
    float jumpCooldown;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        canDJump = false;
    }

    // Update is called once per frame

    void Update()
    {
        CanDJump();
        if (canJump)
        {
            Jump();
        }
        CheckGrounded();
    }

    void CanDJump()
    {
        if (canDJump)
            extraJumps = 1;
        else
            extraJumps = 0;
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (basic.OnGround || jumpCount < extraJumps)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                if (extraJumps > 0)
                {
                    jumpCount++;
                }
                else
                {
                    return;
                }
            }
        }
    }
    void CheckGrounded()
    {
        if (basic.OnGround||basic.OnEnemy)
        {
            jumpCount = 0;
            jumpCooldown = Time.time + 0.0001f;
            canJump = true;
        }
        else if (Time.time < jumpCooldown)
        {
            basic.OnGround = true;
        }
        else
        {
            basic.OnGround = false;
        }
    }


}