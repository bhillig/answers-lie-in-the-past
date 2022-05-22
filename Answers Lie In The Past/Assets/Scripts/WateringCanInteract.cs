using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCanInteract : Interactable
{
    [SerializeField]
    GameObject water;

    // Start is called before the first frame update
    private bool watering = false;

    private SpriteRenderer sr;
    void Start()
    {
        base.Start();
        sr = water.GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        StartCoroutine(SprayWater());
    }

    IEnumerator SprayWater()
    {
        
        if (!watering)
        {
            watering = true;
            sr.enabled = true;
            yield return new WaitForSeconds(1.0f);
            sr.enabled = false;
            watering = false;
        }
    }

}
