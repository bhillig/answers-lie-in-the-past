using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    [SerializeField]
    private float _moveRange;
    [SerializeField]
    private float _duration; //How long do you want the Lerp to last?

    [SerializeField]

    private bool _startOnBottom;

    private Vector2 startPoint;
    private Vector2 endPoint;

    private Vector2 currentPos;

    private bool movingUp;

    private float time = 0;

    void Awake()
    {
        if (_startOnBottom)
        {
            startPoint = this.gameObject.transform.position;
            endPoint = startPoint;
            currentPos = startPoint;
            endPoint.y += _moveRange;
            movingUp = true;
        }
        else 
        {
            endPoint = this.gameObject.transform.position;
            startPoint = endPoint;
            currentPos = endPoint;
            startPoint.y -= _moveRange;
            movingUp = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(movingUp)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
    }

    void MoveUp()
    {
        time += Time.smoothDeltaTime;
        currentPos = Vector2.Lerp(currentPos, endPoint, time/ _duration);
        this.gameObject.transform.position = currentPos;
        if (Vector2.Distance(currentPos, endPoint) < 0.1f) 
        {
            movingUp = false;
            time = 0;
        }
    }

    void MoveDown()
    {
        time += Time.smoothDeltaTime;
        currentPos = Vector2.Lerp(currentPos, startPoint, time/_duration);
        this.gameObject.transform.position = currentPos;
        if (Vector2.Distance(currentPos, startPoint) < 0.1f) 
        {
            movingUp = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(gameObject.transform, true);
        collision.gameObject.GetComponent<PlayerController>().DisableTimeShift();

        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.transform.parent = null;
        DontDestroyOnLoad(collision.gameObject);
        collision.gameObject.GetComponent<PlayerController>().EnableTimeShift();
    }

}
