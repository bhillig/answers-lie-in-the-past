using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCanInteract : Interactable
{
    [SerializeField]
    GameObject water;

    // Start is called before the first frame update
    private bool watering = false;

    private SpriteRenderer srr;
    void Start()
    {
        base.Start();
        srr = water.GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        StateManager.instance.setState("Watered",true);
        StartCoroutine(SprayWater());
    }

    IEnumerator SprayWater()
    {
        
        if (!watering)
        {
            watering = true;
            srr.enabled = true;
            yield return new WaitForSeconds(1.0f);
            srr.enabled = false;
            watering = false;
        }
    }

}
