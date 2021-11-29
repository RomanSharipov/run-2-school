using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedClimb;
    [SerializeField] private float _speedStep;
    [SerializeField] private float _stepSize;

    private float _maxWidth;
    private float _minWidth;
    private PlayerInput _playerInput;
    private Player _player;
    private Rigidbody _rigidbody;
    private Transform _transform;
    private PlayerAnimator _playerAnimator;
    private Vector3 _targetPosition;
    

    private Coroutine _changePosition;
    

    public event UnityAction ClimbedStairs;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
        _player = GetComponent<Player>();
        _targetPosition = _transform.position;
        _minWidth = _transform.position.x -_stepSize;
        _maxWidth = _transform.position.x +_stepSize;
    }

    private void TryClimbStairs()
    {
        if (_player.isCanClimb())
        {
            _transform.Translate(new Vector3(0, Time.deltaTime * _speedClimb, 0));
            ClimbedStairs?.Invoke();
        }
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector3(_targetPosition.x + stepSize, _targetPosition.y, _targetPosition.z);
    }

    public void TryMoveLeft()
    {
        if (_targetPosition.x > _minWidth) 
        {
            Move(-_stepSize);
        }
    }

    public void TryMoveRight()
    {
        if (_targetPosition.x < _maxWidth)
        {
            Move(_stepSize);
        }
    }

    private IEnumerator ChangePosition()
    {
        while (_transform.position != _targetPosition)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _targetPosition, _speedStep * Time.deltaTime);
            yield return null;
        }
        _changePosition = null;
        yield break;
    }


    private void Move(float stepSize)
    {
        SetNextPosition(stepSize);

        if (_changePosition != null)
        {
            StopCoroutine(_changePosition);
            _changePosition = null;
        }
        _changePosition = StartCoroutine(ChangePosition());
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
