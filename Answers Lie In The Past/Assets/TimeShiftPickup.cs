using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShiftPickup : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        if (StateManager.instance.getState("timeshift_pickup"))
        {
            Destroy(this.gameObject);
        }
    }

    public override void Interact()
    {
        PlayerController.instance.EnableTimeShift();
        TimeShiftManager.instance.TimeShift();
        StateManager.instance.setState("timeshift_pickup", true);
        Destroy(this.gameObject);
    }
}
