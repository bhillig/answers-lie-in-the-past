using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPickup : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();   
        if(StateManager.instance.getState("flashlight_pickup"))
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RotateEverySecond();
    }

    void RotateEverySecond()
    {
        transform.Rotate(0, 180.0f * Time.deltaTime, 0);
    }

    public override void Interact()
    {
        FindObjectOfType<Flashlight>().EquipFlashlight();
        StateManager.instance.setState("flashlight_pickup", true);
        Destroy(this.gameObject);
    }
}
