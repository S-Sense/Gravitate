using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAreasScript : MonoBehaviour
{
    public Transform respawnPoint; // Reference to the player's respawn point
    private Vector3 lastRespawnPoint;

    void Start()
    {
        lastRespawnPoint = respawnPoint.position; // Initialize to the starting respawn point
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("KillMurder"))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = lastRespawnPoint; // Move player to last respawn point
    }

    public void UpdateRespawnPoint(Transform newRespawnPoint)
    {
        lastRespawnPoint = newRespawnPoint.position; // Update the last respawn point
    }
}
