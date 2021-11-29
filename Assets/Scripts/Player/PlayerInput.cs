using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    public event UnityAction TriedClimbStairs;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            TriedClimbStairs?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _playerMovement.TryMoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _playerMovement.TryMoveRight();
        }
    }
}
