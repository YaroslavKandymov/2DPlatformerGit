using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private LayerMask LayerMask;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private ContactFilter2D _contactFilter;
    private PlayerMovement _state;

    private readonly RaycastHit2D[] results = new RaycastHit2D[1];

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _state = GetComponent<PlayerMovement>();

        _contactFilter.useTriggers = false;
        _contactFilter.SetLayerMask(LayerMask);
        _contactFilter.useLayerMask = true;
    }

    private void Update()
    {
        if(_state.PlayerDirectionState == PlayerMovement.DirectionState.Left)
        {
            Kill(Vector2.left);
        }
        else
        {
            Kill(Vector2.right);
        }
    }

    private void Kill(Vector2 vector)
    {
        if (Input.GetMouseButtonDown(0))
        {
            var collisionCount = _rigidbody2D.Cast(vector, _contactFilter, results, 2);

            _animator.SetTrigger("Attack");

            if (collisionCount > 0 && results[0].transform.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.Death();
            }
        }
    }
}
