using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadSeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (StateManager.instance.getState("PlantedSeed"))
        {
            transform.position = new Vector3(91.5f, -8.228f, 0.0f);
            if (StateManager.instance.getState("Watered"))
                Destroy(this.gameObject);
        }
    }
}
