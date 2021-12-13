using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private Player _player;

    public event UnityAction TriedClimbStairs;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            TriedClimbStairs?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _player.PlayerMovement.TryMoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _player.PlayerMovement.TryMoveRight();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (_player.IsGrounded)
                return;
            _player.PlayerAnimator.Fall();
        }
    }
}
