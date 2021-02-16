using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public Jump_DJump DJump;
    public Vector3 originalPosition = new Vector3();
    public bool isAlive;

    void Start() {
        DJump.canDJump = false;
        isAlive = true;
    }

    void ResetLevel()
    {
        if (!isAlive)
        {
            player.transform.position = originalPosition;
        }
    }
}
