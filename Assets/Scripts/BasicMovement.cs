using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public Rigidbody2D rb;
    public bool facingRight = true;
    public float movement;
    public int wallJumpDirection = 1;
    public Vector2 bottomOffset;
    public Vector2 leftOffset;
    public Vector2 rightOffset;
    public float collisionRadius;
    public bool OnGround;
    public bool OnRightWall;
    public bool OnLeftWall;
    public bool OnWall;
    public bool OnEnemy;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] LayerMask wallLayer;

    // Update is called once per frame

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        DetectCollisions();
        movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * movementSpeed, rb.velocity.y);
        if (facingRight && movement<0)
            Flip();
        else if (!facingRight && movement>0)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Rotater = transform.localEulerAngles;
        Rotater.y += -180;
        transform.localEulerAngles = Rotater;
        wallJumpDirection *= -1;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset, rightOffset, leftOffset };

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
    }

    void DetectCollisions()
    {
        OnGround    = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
        OnEnemy    = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, enemyLayer);
        OnRightWall = (Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer)||(Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, wallLayer)));
        OnLeftWall  = ((Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer)||Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, wallLayer)));
        OnWall = OnRightWall || OnLeftWall;
    }


}
