using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_DJump : MonoBehaviour
{
    public GameObject player = null;

    public float jumpForce = 5.0f;
    public int extraJumps = 0;

    public bool canDJump = false;

    [SerializeField] LayerMask groundMask;
    [SerializeField] Rigidbody2D rb_body;
    [SerializeField] Transform bottom;

    int jumpCount = 0;
    bool isGrounded;
    float jumpCooldown;

    // Start is called before the first frame update
    void Start()
    {
        rb_body = player.GetComponent<Rigidbody2D>();
        canDJump = false;
    }

    // Update is called once per frame

    void Update()
    {
        CanDJump();
        if (Input.GetButtonDown("Jump"))
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
        if (isGrounded || jumpCount < extraJumps)
        {
            rb_body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
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
    void CheckGrounded()
    {
        if (Physics2D.OverlapCircle(bottom.position, 0.5f, groundMask))
        {
            isGrounded = true;
            jumpCount = 0;
            jumpCooldown = Time.time + 0.0001f;
        }
        else if (Time.time < jumpCooldown)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}