using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    [SerializeField]
    GameObject flashlight;

    private bool isOn = false;

    private void Awake()
    {
        flashlight.SetActive(false);
    }

    private void Update()
    {
        if(isOn)
            HandleAiming();

        if (Input.GetMouseButtonDown(0))
            StartCoroutine(ToggleFlashlight());
    }

    IEnumerator ToggleFlashlight()
    {
        yield return new WaitForSeconds(0.2f);

        if (isOn)
            SoundManager.instance.PlaySoundEffect("flashlight_off");
        else
            SoundManager.instance.PlaySoundEffect("flashlight_on");

        flashlight.SetActive(!isOn);
        isOn = !isOn;
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
