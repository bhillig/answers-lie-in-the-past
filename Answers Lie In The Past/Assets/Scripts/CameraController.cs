using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;

    [SerializeField]
    private Vector3 _offset;

    public static CameraController instance { get; set; }


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

    private void Update()
    {

    }

    private void LateUpdate()
    {
        transform.position = _target.transform.position + _offset;
    }
}
