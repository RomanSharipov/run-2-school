using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Professor _professor;

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
    }

    private void OnDisable()
    {
        _player.HasStopped -= OnStopWalking;
    }

    private void OnStopWalking()
    {
        _animator.SetTrigger("StopWalking");
    }

    public void GiveAss()
    {
        _animator.Play("GiveAss");
    }

    public void TakeDamage()
    {
        _animator.Play("TakeDamage",0,0);
    }

    public void TurnAway()
    {
        _animator.Play("TurnAway");
    }
}
