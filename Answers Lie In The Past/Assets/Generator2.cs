using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator2 : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        if (StateManager.instance.getState("2ndgen"))
        {
            Destroy(this.gameObject);
        }
    }

    public override void Interact()
    {
        StateManager.instance.setState("2ndgen", true);
        SoundManager.instance.PlaySoundEffect("flashlight_on");
        Destroy(this.gameObject);
    }
}
