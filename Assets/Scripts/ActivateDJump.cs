using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDJump : MonoBehaviour
{
    public Color Fairycolor;
    public SpriteRenderer DJfairy;
    public SpriteRenderer WJfairy;
    public SpriteRenderer TeleFairy;
    private SpriteRenderer fairyRenderer;
    public RishavMovement player;

    void Start() 
    {
        fairyRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        setFairies();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            player.canDoubleJump = true;
            player.wallSlide = true;
            //player.GetComponent<SpriteRenderer>().color = Fairycolor;
            //fairyRenderer.sprite = null;
            setFairies();
        }
    }
    void setFairies()
    {
        if (player.canDoubleJump == true)
            DJfairy.enabled = true;
        else
            DJfairy.enabled = false;

        if (player.canWallJump == true)
            WJfairy.enabled = true;
        else
            WJfairy.enabled = false;

        if (player.canTeleport == true)
            TeleFairy.enabled = true;
        else
            TeleFairy.enabled = false;
    }


}
