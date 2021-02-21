using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController5 : MonoBehaviour
{
    public GameObject player;
    public RishavMovement characterMovement;
    public Invisibility invisibility;
    public Jump_DJump DJump;
    public Transform levelOriginalTransform;
    public bool isAlive;

    void Start() {
        characterMovement.canDoubleJump = false;
        characterMovement.canTeleport = false;
        characterMovement.canWallJump = false;
        invisibility.canInvis = true;
        isAlive = true;
    }

    public void ResetPlayer()
    {
        if (!isAlive)
        {
            StartCoroutine(DelaySeconds());
        }
    }

    IEnumerator DelaySeconds()
    {
        yield return new WaitForSeconds(1.0f);
        player.transform.position = levelOriginalTransform.position;
    }
}