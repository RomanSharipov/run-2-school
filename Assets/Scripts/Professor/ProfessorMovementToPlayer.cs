using UnityEngine;

[RequireComponent(typeof(Professor))]
public class ProfessorMovementToPlayer : Professor
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stopDistance;

    private Vector3 _playerPointPosition = new Vector3();

    private float _distanceToPlayer;

    private void OnEnable()
    {
        _playerPointPosition = _player.GetCurrentPosition();
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
            SpankPlayer();
            enabled = false;
        }
    }
}
