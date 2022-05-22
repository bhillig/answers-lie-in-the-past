using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(TilemapCollider2D))]

public class Vines : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 1;

    // state variables
    float _verticalMovement;
    bool growth =false;
    // Start is called before the first frame update
    void Start()
    {
        growth = StateManager.instance.getState("PlantedSeed") && StateManager.instance.getState("Watered");

        GetComponent<TilemapRenderer>().enabled = growth;
        enabled = growth;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            collision.attachedRigidbody.gravityScale = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.attachedRigidbody.gravityScale = 1;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (growth && collision.CompareTag("Player"))
        {
            Debug.Log("trying to climb");
            _verticalMovement = Input.GetAxis("Vertical");
            collision.transform.position += new Vector3(0.0f, _verticalMovement, 0.0f) * _moveSpeed * Time.deltaTime;
        }
    }
}