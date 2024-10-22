using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        DeathAreasScript player = other.GetComponent<DeathAreasScript>();
        if (player != null)
        {
            player.UpdateRespawnPoint(transform); // Update the player's respawn point
        }
    }
}
