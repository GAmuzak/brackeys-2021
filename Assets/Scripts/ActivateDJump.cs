using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDJump : MonoBehaviour
{
    public Color Fairycolor;
    private SpriteRenderer fairyRenderer;
    public RishavMovement player;

    void Start() 
    {
        fairyRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            player.canDoubleJump = true;
            player.GetComponent<SpriteRenderer>().color = Fairycolor;
            //fairyRenderer.sprite = null;
        }
    }


}
