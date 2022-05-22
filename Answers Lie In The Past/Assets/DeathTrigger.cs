using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();
        if(pc != null)
        {
            StartCoroutine(RespawnPlayerAfterOneSecond(pc));
        }
    }

    private IEnumerator RespawnPlayerAfterOneSecond(PlayerController pc)
    {
        pc.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        pc.Respawn();
        pc.gameObject.SetActive(true);
    }
}
