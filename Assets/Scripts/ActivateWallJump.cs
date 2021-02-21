using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWallJump : MonoBehaviour
{
   [SerializeField] RishavMovement characterMovement;
    public Color Fairycolor;
    private SpriteRenderer fairyRenderer;

    private void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            characterMovement.canDoubleJump = true;
            characterMovement.wallSlide = true;
            characterMovement.canWallJump = false;
            characterMovement.canTeleport = false;
            characterMovement.GetComponent<SpriteRenderer>().color = Fairycolor;
        }
    }
}
