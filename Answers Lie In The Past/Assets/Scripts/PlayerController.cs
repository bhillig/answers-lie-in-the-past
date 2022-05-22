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

    private bool canMove = true;
    private bool _facingRight = true;
    private bool _canTimeShift = false;
    public bool FacingRight
    {
        get { return _facingRight; }
    }

    // cache references
    private Rigidbody2D _rb;
    private Animator _animator;

    private Vector2 interactableBoxSize = new Vector2(0.1f, 1f);

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
            DontDestroyOnLoad(this.gameObject);
            Cursor.visible = false;

            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }
    }


    void Update()
    {
        GetInput();
        if(canMove)
            Move();
        playerTransform = transform.position;
    }

    void GetInput()
    {
        _isSprinting = false;

        _horizontalMovement = Input.GetAxis("Horizontal");

        if(Input.GetKey(KeyCode.LeftShift))
            _isSprinting = true;

        if (Input.GetKeyDown(KeyCode.E))
            CheckInteractable();

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_canTimeShift)
            {
                TimeShiftManager.instance.TimeShift();
            }
        }
    }

    private void Move()
    {
        float moveSpeed = _moveSpeed;
        if (_isSprinting)
        {
            moveSpeed = _sprintSpeed;
        }

        if(_facingRight && _horizontalMovement < 0.0f)
        {
            FlipPlayer();
        }
        else if(!_facingRight && _horizontalMovement > 0.0f)
        {
            FlipPlayer();
        }
           
        transform.position += new Vector3(_horizontalMovement, 0.0f, 0.0f) * moveSpeed * Time.deltaTime;

        _animator.SetFloat("Horizontal", Mathf.Abs(_horizontalMovement));
    }

    private void FlipPlayer()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public void TransferPositionOnTimeShift()
    {
        transform.position = playerTransform;
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    public void EnableTimeShift()
    {
        _canTimeShift = true;
    }

    public void CheckInteractable()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, interactableBoxSize, 0f, Vector2.zero);
        foreach(RaycastHit2D hit in hits)
        {
            if (hit.transform.GetComponent<Interactable>())
            {
                hit.transform.GetComponent<Interactable>().Interact();
                return;
            }
        }
    }
}
