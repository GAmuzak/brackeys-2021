using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDJump : MonoBehaviour
{
    private Renderer buttonRenderer;
    [SerializeField] GameObject button;
    [SerializeField] Jump_DJump dJump;
    void Start() {
        buttonRenderer = button.GetComponent<Renderer>();
    }

   private void OnTriggerStay2D(Collider2D other) {
       if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
       {
           buttonRenderer.material.color = Color.green;
           dJump.canDJump = true;
       }
   }
}
