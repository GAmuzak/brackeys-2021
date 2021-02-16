using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateTeleport : MonoBehaviour
{
    private Renderer buttonRenderer;
    [SerializeField] GameObject button;
    [SerializeField] Teleport teleport;
    [SerializeField] GameObject gatewayCover;
    void Start() {
        buttonRenderer = button.GetComponent<Renderer>();
    }

   private void OnTriggerStay2D(Collider2D other) {
       if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
       {
           if (teleport.canTeleport)
           {
            buttonRenderer.material.color = Color.red;
            teleport.canTeleport = false;
            gatewayCover.SetActive(false);
           }
       }
   }
}
