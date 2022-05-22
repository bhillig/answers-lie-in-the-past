using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedInteract : Interactable
{
    [SerializeField]
    GameObject seed;

    void Start()
    {

        base.Start();
        if (StateManager.instance.getState(_stateKey))
        {
            seed.GetComponent<SpriteRenderer>().enabled = true;
            Destroy(this.gameObject);
        }
    }

    public override void Interact()
    {
        seed.GetComponent<SpriteRenderer>().enabled = true;
        StateManager.instance.setState(_stateKey,true);
        Destroy(this.gameObject);
    }
}
