using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        if (StateManager.instance.getState("generator"))
        {
            Destroy(this.gameObject);
        }
    }

    public override void Interact()
    {
        StateManager.instance.setState("generator", true);
        SoundManager.instance.PlaySoundEffect("flashlight_on");
        Destroy(this.gameObject);
    }
}
