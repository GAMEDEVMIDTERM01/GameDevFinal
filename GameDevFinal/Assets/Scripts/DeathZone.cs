using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{

    public float delayBeforeReload = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Perform any death-related actions here (e.g., play death animation, disable controls)
            Debug.Log("Player entered death zone!");

            // Reload the scene after a delay
            Invoke("ReloadScene", delayBeforeReload);
        }
    }

    private void ReloadScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
    
