﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateDJump : MonoBehaviour
{
   private Renderer buttonRenderer;
    [SerializeField] GameObject button;
    [SerializeField] Jump_DJump dJump;
    [SerializeField] GameObject gateCover;
    void Start() {
        buttonRenderer = button.GetComponent<Renderer>();
    }

   private void OnTriggerStay2D(Collider2D other) {
       if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
       {
           buttonRenderer.material.color = Color.red;
           dJump.canDJump = false;
           gateCover.SetActive(false);
       }
   }
}

