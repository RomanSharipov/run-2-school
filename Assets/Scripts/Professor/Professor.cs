using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ProfessorMovementToPlayer))]
[RequireComponent(typeof(ProfessorAttackPlayer))]
[RequireComponent(typeof(ProfessorAnimator))]
public class Professor : MonoBehaviour
{
    private Player _player;
    private ProfessorMovementToPlayer _professorMovementToPlayer;
    private ProfessorAttackPlayer _professorAttackPlayer;
    private ProfessorAnimator _professorAnimator;

    public Player Player => _player;
    public ProfessorAttackPlayer ProfessorAttackPlayer => _professorAttackPlayer;
    public event UnityAction CatchedPlayer;

    private void Awake()
    {
        _professorMovementToPlayer = GetComponent<ProfessorMovementToPlayer>();
        _professorAttackPlayer = GetComponent<ProfessorAttackPlayer>();
        _professorAnimator = GetComponent<ProfessorAnimator>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _player = player;
            CatchedPlayer?.Invoke();
        }
    }

    public void WalkToPlayer()
    {
        _professorAnimator.WalkToPlayer();
        MoveToPlayer();
    }

    public void MoveToPlayer()
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
