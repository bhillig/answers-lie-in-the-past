using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // config parameters
    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private float _sprintSpeed;

    // state variables
    float _horizontalMovement;

    [SerializeField]
    bool _isSprinting;

    // cache references
    private Rigidbody2D _rb;

    public static PlayerController instance { get; private set; }
    public static Vector3 playerTransform { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            _rb = GetComponent<Rigidbody2D>();
            DontDestroyOnLoad(this.gameObject);
        }
    }


    void Update()
    {
        GetInput();
        Move();
        playerTransform = transform.position;
    }

    void GetInput()
    {
        _isSprinting = false;

        _horizontalMovement = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.LeftShift))
            _isSprinting = true;

        if(Input.GetKey(KeyCode.Space))
        {
            TimeShiftManager.instance.TimeShift();
        }
    }

    private void Move()
    {
        float moveSpeed = _moveSpeed;
        if (_isSprinting)
        {
            moveSpeed = _sprintSpeed;
        }
           
        transform.position += new Vector3(_horizontalMovement, 0.0f, 0.0f) * moveSpeed * Time.deltaTime;
    }

    public void TransferPositionOnTimeShift()
    {
        transform.position = playerTransform;
    }
}
