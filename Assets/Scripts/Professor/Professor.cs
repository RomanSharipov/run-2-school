using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ProfessorMovementToPlayer))]
[RequireComponent(typeof(ProfessorAttackPlayer))]
[RequireComponent(typeof(Animator))]
public class Professor : MonoBehaviour
{
    protected Animator _animator;

    protected Player _player;
    protected Transform _transform;

    private ProfessorMovementToPlayer _professorMovementToPlayer;
    private ProfessorAttackPlayer _professorAttackPlayer;

    public event UnityAction CatchedPlayer;

    private void Awake()
    {
        _professorMovementToPlayer = GetComponent<ProfessorMovementToPlayer>();
        _professorAttackPlayer = GetComponent<ProfessorAttackPlayer>();
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _player = player;
            CatchedPlayer?.Invoke();
            _animator.Play("Talk");
        }
    }

    public void PunishPlayer()
    {
        _animator.SetTrigger("PunishPlayer");
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        _professorMovementToPlayer.enabled = true;
    }

    public void SpankPlayer()
    {
        _professorAttackPlayer.enabled = true;
    }

    public void GiveDamage()
    {
        _player.TakeDamage();
    }
}
