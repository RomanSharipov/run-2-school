using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Professor _professor;
    [SerializeField] private Player _player;
    [SerializeField] private Transform CatchedPlayerCameraPoint;
    private Transform _transform;
    private Vector3 offset;
    private float _distanceToPlayerY;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        offset = _transform.position;
        _distanceToPlayerY = _transform.position.y - _player.GetCurrentPosition().y;
    }

    private void LateUpdate()
    {
        _transform.position = new Vector3(offset.x, _player.GetCurrentPosition().y + _distanceToPlayerY, offset.z);
    }

    private void OnEnable()
    {
        _professor.CatchedPlayer += LookAtProfessor;
    }

    private void OnDisable()
    {
        _professor.CatchedPlayer -= LookAtProfessor;
    }

    private void LookAtProfessor()
    {
        _transform.SetParent(CatchedPlayerCameraPoint);
        _transform.localPosition = Vector3.zero;
        _transform.rotation = Quaternion.identity;
        _transform.localRotation = Quaternion.identity;
        enabled = false;
    }
}
