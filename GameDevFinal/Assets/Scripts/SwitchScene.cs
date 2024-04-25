using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    public class SceneChangeOnCollision : MonoBehaviour
    {
        // Define the name of the scene to load
        public int sceneBuildIndex;

        // Function called when a collider enters the trigger
        private void OnTriggerEnter (Collider other)
        {
            // Check if the collider belongs to the player
            if (other.tag == "Player")
            {
                // Load the specified scene
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            }
        }
    }
}