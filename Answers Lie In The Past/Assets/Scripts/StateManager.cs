using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private Dictionary<string,bool> dict = new Dictionary<string, bool>();
    public static StateManager instance { get; set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void setState(string key, bool state=true)
    {
        dict[key] = state;
    }

    public bool getState(string key)
    {
        try
        {
            return dict[key];
        }
        catch(KeyNotFoundException)
        {
            Debug.Log("State " + key + " not found! Initilizing to false.");
            return dict[key] = false; // create new false element
        }
        
    }
}
