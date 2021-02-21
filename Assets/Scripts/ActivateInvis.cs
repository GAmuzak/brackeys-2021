using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateInvis : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Invisibility invisibility;
    public SpriteRenderer InvFairy;


    private void Update()
    {
        setFairies();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            invisibility.canInvis = true;
   
    }
    void setFairies()
    {
        if (invisibility.canInvis == true)
            InvFairy.enabled = true;
        else
            InvFairy.enabled = false;

        
    }

}
