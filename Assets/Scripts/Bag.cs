using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField] private float _distanceBetweenBooks;
    [SerializeField] private Transform _placeFirstBook;

    private Queue<Book> _textbooks;
    private Transform _transform;
    private Vector3 _positionUpperBook;

    private void Start()
    {
        _positionUpperBook = _placeFirstBook.localPosition;
        _textbooks = new Queue<Book>();
        _transform = GetComponent<Transform>();
    }

    public void PutInside(Book book)
    {
        Book newBook = Instantiate(book);
        _textbooks.Enqueue(newBook);
        newBook.transform.SetParent(_transform, true);
        newBook.transform.localPosition = new Vector3(_positionUpperBook.x, _positionUpperBook.y, _positionUpperBook.z);
        _positionUpperBook = new Vector3(_positionUpperBook.x, _positionUpperBook.y + _distanceBetweenBooks, _positionUpperBook.z);
    }
}
