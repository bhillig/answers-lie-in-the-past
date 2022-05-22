using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorHorizontalPlatform : MonoBehaviour
{
    Vector3 startingPosition;

    bool disabled = false;

    // Start is called before the first frame update
    void Start()
    {
        if(!StateManager.instance.getState("generator"))
        {
            disabled = true;
            startingPosition = transform.position;
        }
    }

    private void Update()
    {
        if(disabled)
        {
            transform.position = startingPosition;
        }
    }

}
