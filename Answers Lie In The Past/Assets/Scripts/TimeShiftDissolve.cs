using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeShiftDissolve : MonoBehaviour
{
    private float dissolveDuration = 1.0f;
    private float condenseDuration = 0.0f;

    private Material material;

    public static bool isDissolving = false;
    public static bool isCondensing = false;

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

        if(isCondensing)
        {
            Condense();
        }

    }

    void Dissolve()
    {
        dissolveDuration -= Time.deltaTime;

        if(dissolveDuration <= 0.0f)
        {
            dissolveDuration = 0.0f;
            isDissolving = false;
            TurnOnCondense();
        }

        material.SetFloat("_Fade", dissolveDuration);

        if (dissolveDuration <= 0.0f)
        {
            dissolveDuration = 1.0f;
        }
    }

    void Condense()
    {

        condenseDuration += Time.deltaTime;

        if (condenseDuration >= 1.0f)
        {
            condenseDuration = 1.0f;
            isCondensing = false;
        }

        material.SetFloat("_Fade", condenseDuration);

        if(condenseDuration >= 1.0f)
        {
            condenseDuration = 0.0f;
        }
    }

    public void TurnOnDissolve()
    {
        SoundManager.instance.PlaySoundEffect("dissolve");
        isDissolving = true;
    }

    public void TurnOnCondense()
    {
        SoundManager.instance.PlaySoundEffect("condense");
        isCondensing = true;
    }
}
