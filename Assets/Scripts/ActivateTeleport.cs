using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] RishavMovement characterMovement;
    public SpriteRenderer TeleFairy;

    private void Update()
    {
        setFairies();
    }
    private void OnTriggerStay2D(Collider2D other) 
   {
       if (other.CompareTag("Player"))
       {
           characterMovement.canTeleport = true;
       }
   }
    void setFairies()
    {
        if (characterMovement.canTeleport == true)
            TeleFairy.enabled = true;
        else if (characterMovement.canTeleport == false)
            TeleFairy.enabled = false;
    }
}
