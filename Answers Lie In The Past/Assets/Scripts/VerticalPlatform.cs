using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    [SerializeField]
    private float _moveRange;
    [SerializeField]
    private float _speed; //less than absolute value of 1 slow, greater than fast.

    [SerializeField]

    private bool _startOnBottom;

    private Vector2 startPoint;
    private Vector2 endPoint;

    private Vector2 currentPos;

    private bool movingUp;

    void Awake()
    {
        startPoint = this.gameObject.transform.position;
        currentPos = startPoint;
        endPoint = startPoint;
        if (_startOnBottom)
        {
            endPoint.y += _moveRange;
            movingUp = true;
        }
        else 
        {
            endPoint.y -= _moveRange;
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
        currentPos = Vector2.Lerp(currentPos, endPoint, _speed);
        this.gameObject.transform.position = currentPos;
        if (Vector2.Distance(currentPos, endPoint) < 1f) 
        {
            movingUp = false;
        }
    }

    void MoveDown()
    {
        currentPos = Vector2.Lerp(currentPos, startPoint, _speed);
        this.gameObject.transform.position = currentPos;
        if (Vector2.Distance(currentPos, startPoint) < 1f) 
        {
            movingUp = true;
        }
    }

}
