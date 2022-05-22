using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator2 : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        if (StateManager.instance.getState("gen2"))
        {
            Destroy(this.gameObject);
        }
    }

    public override void Interact()
    {
        StateManager.instance.setState("gen2", true);
        SoundManager.instance.PlaySoundEffect("flashlight_on");
        Destroy(this.gameObject);
    }
}
