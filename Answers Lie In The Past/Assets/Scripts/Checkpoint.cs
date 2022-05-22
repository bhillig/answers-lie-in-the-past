using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // state variable
    bool reachedCheckpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)
        {
            if (!reachedCheckpoint)
            {
                playerController.SetSpawnPoint(this.transform.position);
                reachedCheckpoint = true;
            }

        }
    }
}