using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Professor))]
public class ProfessorAnimator : MonoBehaviour
{
    private Animator _animator;
    private Professor _professor;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _professor = GetComponent<Professor>();
    }

    private void OnEnable()
    {
        _professor.CatchedPlayer += Talk;
        _professor.ProfessorAttackPlayer.Spanked += Spank;
    }

    private void OnDisable()
    {
        _professor.CatchedPlayer -= Talk;
        _professor.ProfessorAttackPlayer.Spanked -= Spank;
    }

    private void Talk()
    {
        _animator.Play(Params.Talk);
    }

    private void Spank()
    {
        _animator.Play(Params.Spank);
    }

    public void PunishPlayer()
    {
        _animator.SetTrigger(Params.PunishPlayer);
    }
}
