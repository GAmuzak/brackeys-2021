using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
  public bool canInvis = false;
  Renderer playerRender;
  Material material; 
  Color originalColour;
  [SerializeField] float invisTime = 3.0f;
  Transform playerTransform;
  [SerializeField] GameObject player;
  [SerializeField] GameObject enemy;
  public bool ignoreCollide;

    void Start() {
        playerRender = GetComponent<Renderer>();
        playerTransform = GetComponent<Transform>();
        canInvis = true;
        originalColour = playerRender.material.color;
        ignoreCollide = false;
    }

    void Update() {
        {
            if (canInvis)
            {
                StartCoroutine(TimeInvis());
            }
        }
    }


    IEnumerator TimeInvis()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            playerRender.material.color = new Color(originalColour.r, originalColour.g, originalColour.b, (originalColour.a/2));
            canInvis = false;  
            Physics2D.IgnoreLayerCollision(11, 10, ignoreCollide = true);
            yield return new WaitForSeconds(invisTime);
            playerRender.material.color = new Color(originalColour.r, originalColour.g, originalColour.b, (originalColour.a));
            canInvis = true;   
            Physics2D.IgnoreLayerCollision(11, 10, ignoreCollide = false);
        }
    }

}
