using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float teleportDistance = 2.0f;
    public Transform playerTransform;
    public bool canTeleport;
    [SerializeField] Rigidbody2D rb;

    // Update is called once per frame
    void Start() {
        canTeleport = false;
    }
    void Update()
    {
        TeleportPlayer();
    }

    void TeleportPlayer() //change as per convinience cuz this too simple and ineffective
    {
        if (canTeleport)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if(rb.velocity.x>0) playerTransform.position = new Vector2(playerTransform.position.x + teleportDistance, playerTransform.position.y);
                else playerTransform.position = new Vector2(playerTransform.position.x - teleportDistance, playerTransform.position.y);
            }
        }
    }
}
