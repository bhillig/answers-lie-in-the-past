using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningNote : Interactable
{
    [SerializeField]
    GameObject note;

    private bool opened = false;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        if(StateManager.instance.getState(_stateKey))
        {
            Destroy(this.gameObject);
        }
    }

    public override void Interact()
    {
        if(!opened)
        {
            opened = true;
            note.SetActive(true);
            PlayerController.instance.DisableMovement();
            StateManager.instance.setState(_stateKey, true);
        }
        else
        { 
            Destroy(this.gameObject);
            PlayerController.instance.EnableMovement();
        }
            
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.CompareTag("Player"))
                Interact();
        }

    }
}
