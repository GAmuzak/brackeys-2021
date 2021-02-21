using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    RishavCollision movementScript;
    RishavMovement move;
    Animator animControl;
    SpriteRenderer sr;
    void Start()
    {
        movementScript = GetComponent<RishavCollision>();
        animControl = GetComponent<Animator>();
        move = GetComponent<RishavMovement>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        animControl.SetBool("onGround", movementScript.onGround);
        animControl.SetBool("onWall", movementScript.onWall);
        animControl.SetBool("onLeftWall", movementScript.onLeftWall);
        animControl.SetBool("onRightWall", movementScript.onRightWall);
        animControl.SetBool("onGround", movementScript.onGround);
    }

    public void setAxes(float x, float y, float vVel)
    {
        animControl.SetFloat("horizontal", Mathf.Abs(x));
        animControl.SetFloat("vertical", Mathf.Abs(y));
        animControl.SetFloat("verticalVelocity", vVel);
    }

    public void Flip(int side)
    {

        if (move.wallSlide)
        {
            if (side == -1 && sr.flipX)
                return;

            if (side == 1 && !sr.flipX)
            {
                return;
            }
        }

        bool state = (side == 1) ? false : true;
        sr.flipX = state;
    }
}
