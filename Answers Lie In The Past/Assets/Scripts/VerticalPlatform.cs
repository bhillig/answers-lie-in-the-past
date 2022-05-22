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
        currentPos = Vector2.Lerp(currentPos, endPoint, _speed*Time.smoothDeltaTime);
        this.gameObject.transform.position = currentPos;
        if (Vector2.Distance(currentPos, endPoint) < 1f) 
        {
            movingUp = false;
        }
    }

    void MoveDown()
    {
        currentPos = Vector2.Lerp(currentPos, startPoint, _speed*Time.smoothDeltaTime);
        this.gameObject.transform.position = currentPos;
        if (Vector2.Distance(currentPos, startPoint) < 1f) 
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
