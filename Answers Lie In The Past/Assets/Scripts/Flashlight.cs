using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    Transform flashlightTransform;


    private void Update()
    {
        HandleAiming();
    }

    void HandleAiming()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector2 direction;
        if (mousePosition.x < 0 || mousePosition.y < 0)
        {
            mousePosition.x = Mathf.Max(0, mousePosition.x);
            mousePosition.y = Mathf.Max(0, mousePosition.y);
        }

        if (mousePosition.x > Screen.width || mousePosition.y > Screen.height)
        {
            mousePosition.x = Mathf.Min(Screen.width, mousePosition.x);
            mousePosition.y = Mathf.Min(Screen.height, mousePosition.y);
        }
        direction = new Vector2(mousePosition.x - Screen.width / 2, mousePosition.y - Screen.height / 2);
        gameObject.transform.right = direction;
        
    }

}
