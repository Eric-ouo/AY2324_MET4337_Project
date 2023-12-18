using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Assign this from the inspector, drag the spawn point GameObject here
    public Transform spawnPoint;

    private void Start()
    {
        // Move the player to the spawn point at the start of the game
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        if (spawnPoint != null)
        {
            // Set the player's position to the spawn point position
            transform.position = spawnPoint.position;
        }
        else
        {
            Debug.LogError("Spawn Point not assigned to PlayerController script.", this);
        }
    }

    // Call this method when a goal is scored
    public void RespawnAfterGoal()
    {
        // You can add delay or animations as needed
        SpawnPlayer();
    }
}