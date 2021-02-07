using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    readonly Vector2 _force = new Vector2(0, 400);

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private bool _inAir;
    private Vector3 _leftDirection;
    private Vector3 _rightDirection;
    private DirectionState _direction = DirectionState.Left;

    public DirectionState PlayerDirectionState => _direction;

    public enum DirectionState
    {
        Right,
        Left
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _leftDirection = new Vector3(1, 1, 1);
        _rightDirection = new Vector3(-1, 1, 1);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = _leftDirection;
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);

            _direction = DirectionState.Left;

            _animator.SetFloat("Speed", 2f);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = _rightDirection;
            transform.Translate(_speed * Time.deltaTime, 0, 0);

            _direction = DirectionState.Right;

            _animator.SetFloat("Speed", 2f);
        }


        if (Input.GetKey(KeyCode.Space) && _inAir == false)
        {
            _inAir = true;
            _rigidbody2D.AddForce(_force);
            _animator.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            _inAir = false;
    }
}
