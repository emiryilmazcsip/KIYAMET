using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string nextSceneName = "EndDemoCredits"; // Name of the next scene
    public GameObject player; // Reference to the player GameObject

    private bool playerInRange = false; // Flag to track if player is in range

    // Called when another Collider enters this object's trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.gameObject == player)
        {
            playerInRange = true; // Set the player in range flag
        }
    }

    // Called when another Collider exits this object's trigger collider
    private void OnTriggerExit(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.gameObject == player)
        {
            playerInRange = false; // Reset the player in range flag
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if player is in range and pressing a specific key (e.g., 'E' key)
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
