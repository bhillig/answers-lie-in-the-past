using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public abstract class Interactable : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    [SerializeField]
    protected string _stateKey;

    private GameObject spriteObj;

    private SpriteRenderer sr;

    private Sprite e;

    protected void Start()
    {
        Debug.Log("CALLED");

        spriteObj = new GameObject("IconHolder");
        spriteObj.AddComponent<SpriteRenderer>();

        sr = spriteObj.GetComponent<SpriteRenderer>();
        if (sr == null)
            Debug.Log("Null");

        sr.sprite = Resources.Load<Sprite>("eSprite");
        sr.size = new Vector2(1,1);
        sr.sortingOrder = 2;
        sr.transform.position = transform.position + new Vector3(0.0f,1.0f,0.0f);

        sr.enabled = false;
    }

    public abstract void Interact();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sr.enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (collision.CompareTag("Player"))
                Interact();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sr.enabled = false;
    }
}
