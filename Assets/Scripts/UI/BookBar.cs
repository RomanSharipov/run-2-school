using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookBar : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] private Text _symbol;
    [SerializeField] private Player _player;
    [SerializeField] private Professor _professor;
    [SerializeField] private Transform _newBarPoint;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        _player.Bag.AddedBook += OnChangeBar;
        _player.Bag.ReduceBook += OnChangeBar;
        _professor.CatchedPlayer += CorrectBarPosition;
    }

    private void OnDisable()
    {
        _player.Bag.AddedBook -= OnChangeBar;
        _player.Bag.ReduceBook -= OnChangeBar;
        _professor.CatchedPlayer -= CorrectBarPosition;
    }

    private void OnChangeBar(Book book)
    {
        _bar.color = book.ColorBar;
        _symbol.text = book.Symbol;
        _symbol.color = book.ColorBar;
        _bar.fillAmount = _player.Bag.GetCountBooks(book) * 0.1f ;
    }

    private void CorrectBarPosition()
    {
        _transform.position = _newBarPoint.position;
    }
}
