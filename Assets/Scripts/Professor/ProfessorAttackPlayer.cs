using UnityEngine;

public class ProfessorAttackPlayer : Professor
{
    [SerializeField] private float _delay;
    [SerializeField] private int _countSpanks;

    
    private int _currentCountSpanks;
    private float _lastAttackTime;

    private void Update()
    {
        if (_currentCountSpanks == _countSpanks)
        {
            StartCoroutine(_player.TurnAway());
            enabled = false;
        }
        
        if (_lastAttackTime <= 0 ) 
        {
            _animator.Play("Spank");
            _lastAttackTime = _delay;
            _currentCountSpanks++;
        }
        _lastAttackTime -= Time.deltaTime;
    }
}
