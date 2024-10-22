using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnableSprite : MonoBehaviour
{
    // Reference to the 2D SpriteRenderer to enable
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Enable the SpriteRenderer
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = true;
            }
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
        // Optionally, disable the SpriteRenderer when the player exits the trigger
        //if (other.CompareTag("Player"))
        //{
            //if (spriteRenderer != null)
            //{
                //spriteRenderer.enabled = false;
            //}
        //}
    //}
}