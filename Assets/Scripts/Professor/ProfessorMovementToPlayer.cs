using UnityEngine;

[RequireComponent(typeof(Professor))]
public class ProfessorMovementToPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stopDistance;

    private Vector3 _playerPointPosition = new Vector3();

    [SerializeField] private float _distanceToPlayer;
    private Professor _professor;
    private Transform _transform;

    private void Awake()
    {
        _professor = GetComponent<Professor>();
        _transform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        _playerPointPosition = _professor.Player.GetCurrentPosition();
    }

    private void Update()
    {
        _distanceToPlayer = Vector3.Distance(_transform.position, _playerPointPosition);

        if (_distanceToPlayer > _stopDistance) 
        {
            _transform.localPosition = Vector3.MoveTowards(_transform.localPosition, _playerPointPosition, _speed * Time.deltaTime);
        }
        else
        {
            _professor.SpankPlayer();
            enabled = false;
        }
    }
}
