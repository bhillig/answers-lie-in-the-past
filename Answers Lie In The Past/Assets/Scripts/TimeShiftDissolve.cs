using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShiftDissolve : MonoBehaviour
{
    private float dissolveDuration = 1.0f;

    private Material material;

    public static bool isDissolving = false;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        if(material == null)
        {
            Debug.Log("Warning: Object " + gameObject.name + " does not have a material!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isDissolving)
        {
            Dissolve();
        }

        material.SetFloat("_Fade", dissolveDuration);
    }

    void Dissolve()
    {
        dissolveDuration -= Time.deltaTime;
        if(dissolveDuration <= 0.0f)
        {
            dissolveDuration = 0.0f;
            isDissolving = false;
        }

        if(dissolveDuration <= 0.0f)
        {
            dissolveDuration = 1.0f;
        }
    }

    public void TurnOnDissolve()
    {
        isDissolving = true;
    }
}
