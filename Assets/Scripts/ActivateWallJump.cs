using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWallJump : MonoBehaviour
{
    [SerializeField] RishavMovement characterMovement;
    public SpriteRenderer DJfairy;
    public SpriteRenderer WJfairy;
    public SpriteRenderer TeleFairy;
    public Color Fairycolor;
    private SpriteRenderer fairyRenderer;

    private void Update()
    {
        setFairies();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            characterMovement.canWallJump = true;
            characterMovement.wallSlide = true;
            //characterMovement.GetComponent<SpriteRenderer>().color = Fairycolor;
            setFairies();
        }
    }

    void setFairies()
    {
 

        if (characterMovement.canWallJump == true)
            WJfairy.enabled = true;
        else
            WJfairy.enabled = false;

        
    }
}
