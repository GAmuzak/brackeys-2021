using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene1 : MonoBehaviour
{
    [SerializeField] GameObject gateway;
    public string loadLevel;
    [SerializeField] Jump_DJump dJump;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !dJump.canDJump)
        {
            gateway.SetActive(false);
            SceneManager.LoadScene(loadLevel);
        }
    }
}
