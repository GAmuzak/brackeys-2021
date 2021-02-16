using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene2 : MonoBehaviour
{
    [SerializeField] GameObject gateway;
    public string loadLevel;
    [SerializeField] Teleport teleport;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !teleport.canTeleport)
        {
            gateway.SetActive(false);
            SceneManager.LoadScene(loadLevel);
        }
    }
}
