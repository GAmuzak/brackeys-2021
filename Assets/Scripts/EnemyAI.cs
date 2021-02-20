using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] BasicMovement basic;
    [SerializeField] EnemyPatrol patrol;
    [SerializeField] Invisibility invisibility;
    [SerializeField] float agroRange;
    [SerializeField] Transform castPoint;
    [SerializeField] float patrolSpeed;
    [SerializeField] float delayTime;
    float enemySpeed;
    Rigidbody2D rb2d;
    public bool isFacingRight;
    public bool isAgro;
    bool isSearching;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemySpeed = basic.movementSpeed - 1.5f;
    }

    // Update is called once per frame
    void Update()
    {

        if (CanSeePlayer(agroRange))
        {
            isAgro = true;
            ChasePlayer();
        }

        else
        {
            if(isAgro && !isSearching)
            {
                isSearching = true;
                Invoke(nameof(StopChasingPlayer), 5);
            }
                
        }

        if(isAgro)
            ChasePlayer();
    }

    void ChasePlayer()
    {
        if (transform.position.x<player.position.x)
        {
            rb2d.velocity = new Vector2(enemySpeed,0);
            transform.localScale = new Vector3(Mathf.Sign(rb2d.velocity.x), transform.localScale.y,transform.localScale.z);
            isFacingRight = true;
        }

        else{
            rb2d.velocity = new Vector2(-enemySpeed,0);
            transform.localScale = new Vector3(Mathf.Sign(rb2d.velocity.x), transform.localScale.y,transform.localScale.z);
            isFacingRight = false;
        }
    }

    void StopChasingPlayer()
    {
        isAgro = false;
        isSearching = false;
        rb2d.velocity = new Vector2(0,0);
        StartCoroutine(Delay(delayTime));
    }

    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        if (!isFacingRight)
        {
            castDist = -distance;
        }
        Vector2 endPos = castPoint.position + Vector3.right * castDist;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (!invisibility.ignoreCollide)
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    val = true;
                }
                Debug.DrawLine(castPoint.position, hit.point, Color.yellow);
            }

            else{
                Debug.DrawLine(castPoint.position, endPos, Color.red);
            }
        }
        
        return val;
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        patrol.Patrol();
    }
    
}
    
    
