using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedClimb;
    [SerializeField] private Bag _bag;

    private PlayerInput _playerInput;
    private Rigidbody _rigidbody;
    private Transform _transform;

    public event UnityAction ClimbedStairs;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        _transform.Translate(new Vector3(0, 0, Time.deltaTime * _speed));
    }

    private void TryClimbStairs()
    {
        if (_bag.IsEmpty())
            return;
        _transform.Translate(new Vector3(0, Time.deltaTime * _speedClimb, 0));
        ClimbedStairs?.Invoke();
    }

    private void OnEnable()
    {
        _playerInput.TriedClimbStairs += TryClimbStairs;
    }

    private void OnDisable()
    {
        _playerInput.TriedClimbStairs -= TryClimbStairs;
    }
}
