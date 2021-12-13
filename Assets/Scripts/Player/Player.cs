using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Bag _bag;
    [SerializeField] private Professor _professor;
    [SerializeField] private float _delayBeforeTurnAway;
    [SerializeField] private ParticleSystem _angrySmile;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private Transform _angrySmileSpawnPoint;

    private PlayerInput _playerInput;
    private Transform _transform;
    private PlayerMovement _playerMovement;
    private PlayerAnimator _playerAnimator;
    private Vector3 _startPosition = new Vector3();

    public event UnityAction TakenDamage;

    public Bag Bag => _bag;
    public PlayerAnimator PlayerAnimator => _playerAnimator;
    public PlayerMovement PlayerMovement => _playerMovement;
    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _transform = GetComponent<Transform>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _startPosition = _transform.position;
    }

    public event UnityAction HasStopped;

    public void TakeBook(Book book)
    {
        _bag.PutInside(book);
    }

    public bool isCanClimb()
    {
        return _bag.IsEmpty() == false;
    }

    public void TakeDamage()
    {
        ParticleSystem angrySmile = Instantiate(_angrySmile, _angrySmileSpawnPoint.position,Quaternion.identity);
        _bag.GetBook();
        TakenDamage?.Invoke();
    }

    public void StopMoving()
    {
        _playerInput.enabled = false;
        HasStopped?.Invoke();
    }

    public Vector3 GetCurrentPosition()
    {
        return _transform.position;
    }

    public void ResetPosition()
    {
        _transform.position = new Vector3(_startPosition.x, _transform.position.y, _transform.position.z);
    }

    public void GiveAss()
    {
        _playerAnimator.GiveAss();
    }

    public IEnumerator TurnAway()
    {
        var waitForSeconds = new WaitForSeconds(_delayBeforeTurnAway);
        yield return waitForSeconds;
        _playerAnimator.TurnAway();
    }

    private void OnCollisionEnter(Collision other)
    {
        _isGrounded = true;
        _playerAnimator.ToLand();
    }

    private void OnCollisionExit(Collision other)
    {
        _isGrounded = false;
        _playerAnimator.ToLand();
    }
}
