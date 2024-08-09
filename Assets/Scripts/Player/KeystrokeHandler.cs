using UnityEngine;

[RequireComponent(typeof(Animator))]
public class KeystrokeHandler : MonoBehaviour
{
    private const string Run = "Run";
    private const string Bounce = "Jump";
    private const string Attack = "Attack";
    private const string Horizontal = "Horizontal";

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _feetPosition;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _checkRadius;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveInput;
    [SerializeField] private float _speed;

    [SerializeField] private Transform _transformSliser;
    [SerializeField] private Transform _transformPlayer;

    private Animator _animator;
    private bool _facingRight = false;
    private bool _isJump = false;

    public bool IsGrounded { get; private set; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _moveInput = Input.GetAxis(Horizontal);

        RunPlayer();
        Jump();
        TurnPlayer();
        Assault();
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

    private void RunPlayer()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);

            RunAnimPlayer();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);

            RunAnimPlayer();
        }
        else
        {
            StopAnimPlayer();
        }
    }

    private void Jump()
    {
        if (IsGrounded && Input.GetKey(KeyCode.Space))
        {
            _isJump = true;
            _animator.SetBool(Bounce, true);
        }
        else
        {
            _animator.SetBool(Bounce, false);
        }
    }

    private void Assault()
    {
        if (IsGrounded && Input.GetKey(KeyCode.F))
            _animator.SetTrigger(Attack);
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
            _animator.SetBool(Run, true);
    }

    private void StopAnimPlayer()
    {
        _animator.SetBool(Run, false);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
