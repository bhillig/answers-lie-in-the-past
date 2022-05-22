using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedInteract : Interactable
{
    [SerializeField]
    GameObject seed;

    public override void Interact()
    {
        seed.GetComponent<SpriteRenderer>().enabled = true;

        Destroy(this.gameObject);
    }
}
