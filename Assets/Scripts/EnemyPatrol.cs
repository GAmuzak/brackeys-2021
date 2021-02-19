using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] float patrolSpeed;
    [SerializeField] EnemyAI sensePlayer;
    public bool onPatrol;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Patrol();
    }
   void OnTriggerExit2D(Collider2D collision) {
        transform.localScale = new Vector3(-(Mathf.Sign(rb2d.velocity.x)),transform.localScale.y,transform.localScale.z);
    }

    bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    public void Patrol()
    {
        if (IsFacingRight())
        {
            rb2d.velocity = new Vector2(patrolSpeed,0);
            sensePlayer.isFacingRight = true;
        }

        else if(!IsFacingRight())
        {
            rb2d.velocity = new Vector2(-patrolSpeed,0);
            sensePlayer.isFacingRight = false;
        }
    }
}
