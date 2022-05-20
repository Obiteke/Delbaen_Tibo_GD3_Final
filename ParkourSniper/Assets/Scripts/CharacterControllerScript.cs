using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControllerScript : MonoBehaviour
{
    #region Fields
    public Vector3 _moveDir = Vector3.zero;
    private Vector2 _moveInput;
    private bool _isMoving = false;
    private bool _isJumping = false;
    private bool _isSlipping = false;
    private bool _isJumpingPressed;
    private Rigidbody _rigidBody;


    private Vector2 _rotateInput;
    private bool _isRotating = false;

    //private Animator _animator;
    public CharacterController _cc;

    [SerializeField]
    private Animator _animator;
    public GameObject _cam;

    public float topSpeed;
    public float RotatingSpeed= 1.0f;

    private float _gravity = -7f;
    private float _groundedGravity = -0.05f;

    private float _kBForce = 10f;
    private float kBTime = 0.25f;
    private float kBCounter;

    private float _initialJumpVelocity;
    public float _maxJumpHeight = 4f;
    public float _maxJumpTime = 0.75f;

    private float timeZeroToMax = 0.5f;
    private float acceleration;
    private float CurrentSpeed= 0;

    public bool isRunnerCharacter;
    #endregion

    #region Properties
    public bool IsMoving { get => _isMoving; set => _isMoving = value; }
    public bool IsRotating { get => _isRotating; set => _isRotating = value; }
    #endregion

    #region Methods
    private void Awake()
    {
        acceleration = topSpeed / timeZeroToMax;

        //_animator = gameObject.GetComponentInChildren<Animator>();
        _cc = gameObject.GetComponent<CharacterController>();
        setupJumpVariables();

        _rigidBody = GetComponent<Rigidbody>();
    }

    //private void SetCamera()
    //{
    //    _cam.transform.position = new Vector3(_cam.transform.position.x + transform.position.x, _cam.transform.position.y + transform.position.y, _cam.transform.position.z + transform.position.z);
    //}

    private void setupJumpVariables()
    {
        float timeToApex = _maxJumpTime / 2;
        _gravity = (-2 * _maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        _initialJumpVelocity = (2 * _maxJumpHeight) / timeToApex;
    }

    void FixedUpdate()
    {
        HandleGravity();
        if (kBCounter <= 0)
        {
            Movement();
            HandleJump();
        }
        else
            kBCounter -= Time.fixedDeltaTime;
        
        _cc.Move(_moveDir * Time.fixedDeltaTime);
    }

    public void HandleGravity()
    {
        bool isFalling = _moveDir.y <= 0f || !_isJumpingPressed;
        float fallMultiplier = 2.0f;

        if (_cc.isGrounded)
            _moveDir.y = _groundedGravity;
        else if (isFalling)
        {
            float previousYVelocity = _moveDir.y;
            float newYVelocity = _moveDir.y + (_gravity * fallMultiplier * Time.fixedDeltaTime);
            float nextYVelocity = (previousYVelocity + newYVelocity) * .5f;
            _moveDir.y = nextYVelocity;
        }
        else
        {
            float previousYVelocity = _moveDir.y;
            float newYVelocity = _moveDir.y + (_gravity * Time.fixedDeltaTime);
            float nextYVelocity = (previousYVelocity + newYVelocity) * .5f;
            _moveDir.y = nextYVelocity;
        }
        //https://www.youtube.com/watch?v=h2r3_KjChf4 video about jumping
    }
    public void MovementInput(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();

        Rotation();
        if (context.performed)
            IsMoving = true;

        if (context.canceled)
            IsMoving = false;
    }

    public void JumpingInput(InputAction.CallbackContext context)
    {
        _isJumpingPressed = context.ReadValueAsButton();
    }
    private void HandleJump()
    {
        if (!_isJumping && _isJumpingPressed)//&& _cc.isGrounded
        {
            if (isRunnerCharacter)
                _animator.SetBool("IsJumping", true);

            _isJumping = true;
            _moveDir.y = _initialJumpVelocity * .5f;
        }
        else if (!_isJumpingPressed && _isJumping && _cc.isGrounded)
        {
            _isJumping = false;
            if (isRunnerCharacter)
                _animator.SetBool("IsJumping", false);
        }
    }


    private void Movement()
    {
        //CurrentSpeed += acceleration * Time.fixedDeltaTime;
        //CurrentSpeed = Mathf.Min(CurrentSpeed, topSpeed);
        if (IsMoving)
        {
            if (_moveInput.x != 0 || _moveInput.y != 0)
            {
                CurrentSpeed += acceleration * Time.fixedDeltaTime;
                CurrentSpeed = Mathf.Min(CurrentSpeed, topSpeed);

                _moveDir = new Vector3(CurrentSpeed * _moveInput.x, _moveDir.y, CurrentSpeed * _moveInput.y);
                if(isRunnerCharacter)
                    _animator.SetBool("IsRunning", true);
            }
        }
        else
        {
            if(CurrentSpeed >= 0)
            {
                CurrentSpeed -= acceleration * Time.fixedDeltaTime;
                CurrentSpeed = Mathf.Max(CurrentSpeed, 0);
            }

            if (isRunnerCharacter)
                    _animator.SetBool("IsRunning", false);
            _moveDir = new Vector3(0, _moveDir.y, 0);
        }
    }
    private void Rotation()
    {
        if (isRunnerCharacter)
        {
            if (_moveInput.x != 0 || _moveInput.y != 0)
            {
                float angle = Mathf.Atan2(_moveInput.x, _moveInput.y) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, angle, 0);
            }
        }
    }
    public void Knockback(Vector3 enemyPosition)
    {
        Vector3 dir = -(enemyPosition - gameObject.transform.position).normalized;
        _moveDir = dir * _kBForce;

        kBCounter = kBTime;
    }


    #endregion
}
