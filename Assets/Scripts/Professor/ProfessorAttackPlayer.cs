using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Professor))]
public class ProfessorAttackPlayer : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private int _countSpanks;

    private int _currentCountSpanks;
    private float _lastAttackTime;
    private Professor _professor;

    public event UnityAction Spanked;

    private void Awake()
    {
        _professor = GetComponent<Professor>();
    }

    private void Update()
    {
        if (_currentCountSpanks == _countSpanks)
        {
            StartCoroutine(_professor.Player.TurnAway());
            enabled = false;
        }
        
        if (_lastAttackTime <= 0 ) 
        {
            Spanked?.Invoke();
            _lastAttackTime = _delay;
            _currentCountSpanks++;
        }
        _lastAttackTime -= Time.deltaTime;
    }

}
