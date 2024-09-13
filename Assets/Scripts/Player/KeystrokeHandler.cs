using System;
using UnityEngine;

public class KeystrokeHandler : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    private const KeyCode Vampire = KeyCode.Q;
    private const KeyCode Weaponize = KeyCode.F;
    private const KeyCode GoLeft = KeyCode.A;
    private const KeyCode GoRight = KeyCode.D;
    private const KeyCode JumpUp = KeyCode.Space;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _feetPosition;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _checkRadius;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveInput;
    [SerializeField] private float _speed;

    [SerializeField] private Transform _transformPlayer;

    public event Action Vampirism;
    public event Action StartedJump;
    public event Action FinishedJump;
    public event Action Attack;
    public event Action StartRunning;
    public event Action Stay;

    private bool _facingRight = false;
    private bool _isJump = false;

    public bool IsGrounded { get; private set; }
    public bool CanMove { get; private set; }

    private void Start()
    {
        LetMove();
    }

    private void Update()
    {
        _moveInput = Input.GetAxis(Horizontal);

        RunPlayer();
        Jump();
        TurnPlayer();
        Assault();
        ActivateVampirism();
    }

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(_feetPosition.position,
                                             _checkRadius,
                                             _whatIsGround);

        if (_isJump)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
            _isJump = false;
        }
    }

    public void LetMove() =>
        CanMove = true;

    public void ForbidMove() =>
        CanMove = false;

    private void RunPlayer()
    {
        if (Input.GetKey(GoRight))
        {
            if (CanMove)
            {
                transform.Translate(_speed * Time.deltaTime, 0, 0);

                RunAnimPlayer();
            }
        }
        else if (Input.GetKey(GoLeft))
        {
            if (CanMove)
            {
                transform.Translate(_speed * Time.deltaTime * -1, 0, 0);

                RunAnimPlayer();
            }
        }
        else
        {
            StopAnimPlayer();
        }
    }

    private void ActivateVampirism()
    {
        if (Input.GetKeyDown(Vampire))
            Vampirism?.Invoke();
    }

    private void Jump()
    {
        if (IsGrounded && Input.GetKey(JumpUp))
        {
            if (CanMove)
            {
                _isJump = true;
                StartedJump?.Invoke();
            }
        }
        else
        {
            FinishedJump?.Invoke();
        }
    }

    private void Assault()
    {
        if (IsGrounded && Input.GetKey(Weaponize))
            Attack?.Invoke();
    }

    private void TurnPlayer()
    {
        if (_facingRight == false && _moveInput > 0)
            Flip();
        else if (_facingRight && _moveInput < 0)
            Flip();
    }

    private void RunAnimPlayer()
    {
        if (IsGrounded)
            StartRunning?.Invoke();
    }

    private void StopAnimPlayer() =>
        Stay?.Invoke();

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector2 scaler = _transformPlayer.localScale;
        scaler.x *= -1;
        _transformPlayer.localScale = scaler;
    }
}
