using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    [SerializeField]
    private float _moveRange;
    [SerializeField]
    private float _speed; //less than absolute value of 1 slow, greater than fast.

    [SerializeField]

    private bool _startOnLeft;

    private Vector2 startPoint;
    private Vector2 endPoint;

    private Vector2 currentPos;

    private bool movingRight;

    void Awake()
    {
        startPoint = this.gameObject.transform.position;
        currentPos = startPoint;
        endPoint = startPoint;
        if (_startOnLeft)
        {
            endPoint.x += _moveRange;
            movingRight = true;
        }
        else 
        {
            endPoint.x -= _moveRange;
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
        currentPos = Vector2.Lerp(currentPos, endPoint, _speed*Time.smoothDeltaTime);
        this.gameObject.transform.position = currentPos;
        if (Vector2.Distance(currentPos, endPoint) < 1f) 
        {
            movingRight = false;
        }
    }

    void MoveLeft()
    {
        currentPos = Vector2.Lerp(currentPos, startPoint, _speed*Time.smoothDeltaTime);
        this.gameObject.transform.position = currentPos;
        if (Vector2.Distance(currentPos, startPoint) < 1f) 
        {
            movingRight = true;
        }
    }


}
