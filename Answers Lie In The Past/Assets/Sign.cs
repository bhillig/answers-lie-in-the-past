using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField]
    private GameObject signCanvas;

    void Start()
    {
        signCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        signCanvas.SetActive(true);   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        signCanvas.SetActive(false);
    }
}
