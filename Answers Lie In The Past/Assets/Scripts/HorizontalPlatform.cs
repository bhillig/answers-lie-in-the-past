using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    [SerializeField]
    private float _moveRange;
    [SerializeField]
    private float _duration; //How long do you want the journey to be in seconds?

    [SerializeField]

    private bool _startOnLeft;

    private Vector2 startPoint;
    private Vector2 endPoint;

    private Vector2 currentPos;

    private bool movingRight;

    private float time = 0;

    void Awake()
    {
        if (_startOnLeft)
        {
            startPoint = this.gameObject.transform.position;
            endPoint = startPoint;
            currentPos = startPoint;
            endPoint.x += _moveRange;
            movingRight = true;
        }
        else 
        {
            endPoint = this.gameObject.transform.position;
            startPoint = endPoint;
            currentPos = endPoint;
            startPoint.x -= _moveRange;
            movingRight = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(movingRight)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }

    void MoveRight()
    {
        time += Time.smoothDeltaTime;
        currentPos = Vector2.Lerp(currentPos, endPoint, time/_duration);
        this.gameObject.transform.position = currentPos;
        if (Vector2.Distance(currentPos, endPoint) < 0.1f) 
        {
            movingRight = false;
            time = 0;
        }
    }

    void MoveLeft()
    {
        time += Time.smoothDeltaTime;
        currentPos = Vector2.Lerp(currentPos, startPoint, time/_duration);
        this.gameObject.transform.position = currentPos;
        if (Vector2.Distance(currentPos, startPoint) < 0.1f) 
        {
            movingRight = true;
            time = 0;
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
