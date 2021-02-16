using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer buttonRenderer;
    [SerializeField] GameObject button;
    [SerializeField] Teleport teleport;
    void Start() {
        buttonRenderer = button.GetComponent<Renderer>();
    }

   private void OnTriggerStay2D(Collider2D other) {
       if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
       {
           buttonRenderer.material.color = Color.green;
           teleport.canTeleport = true;
       }
   }
}
