using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
  public bool canInvis = false;
  [SerializeField] SpriteRenderer playerRender;
  Color originalColour;
  [SerializeField] float invisTime = 3.0f;
  Transform playerTransform;

  public bool ignoreCollide;

    void Start() {
        playerTransform = GetComponent<Transform>();
        canInvis = true;
        originalColour = playerRender.color;
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
            playerRender.color = new Color(originalColour.r, originalColour.g, originalColour.b, (originalColour.a/2));
            canInvis = false;  
            Physics2D.IgnoreLayerCollision(11, 10, ignoreCollide = true);
            yield return new WaitForSeconds(invisTime);
            playerRender.color = new Color(originalColour.r, originalColour.g, originalColour.b, (originalColour.a));
            canInvis = true;   
            Physics2D.IgnoreLayerCollision(11, 10, ignoreCollide = false);
        }
    }

}
