using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Player _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _player.HasStopped += OnStopWalking;
        _player.TakenDamage += OnTakeDamage;
    }

    private void OnDisable()
    {
        _player.HasStopped -= OnStopWalking;
        _player.TakenDamage -= OnTakeDamage;
    }

    private void OnStopWalking()
    {
        _animator.SetTrigger(Params.StopWalking);
    }

    public void GiveAss()
    {
        _animator.Play(Params.GiveAss);
    }

    private void OnTakeDamage()
    {
        _animator.Play(Params.TakeDamage, 0,0);
    }

    public void TurnAway()
    {
        _animator.Play(Params.TurnAway);
    }

    public void Fall()
    {
        _animator.SetBool(Params.IsGrounded,false);
    }

    public void ToLand()
    {
        _animator.SetBool(Params.IsGrounded, true);
    }
}
