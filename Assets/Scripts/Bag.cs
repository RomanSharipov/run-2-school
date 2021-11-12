using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField] private float _distanceBetweenBooks;
    [SerializeField] private Transform _placeFirstBook;
    [SerializeField] private Vector3 _scaleBookInBag;

    private Stack<Book> _textbooks;
    private Transform _transform;
    private Vector3 _positionUpperBook;

    private void Start()
    {
        _positionUpperBook = _placeFirstBook.localPosition;
        _textbooks = new Stack<Book>();
        _transform = GetComponent<Transform>();
    }

    public void PutInside(Book book)
    {
        Book newBook = Instantiate(book);
        _textbooks.Push(newBook);
        newBook.transform.SetParent(_transform, true);
        newBook.transform.localPosition = new Vector3(_positionUpperBook.x, _positionUpperBook.y, _positionUpperBook.z);
        newBook.ChangeScaleNewBook(_scaleBookInBag);
        _positionUpperBook = new Vector3(_positionUpperBook.x, _positionUpperBook.y + _distanceBetweenBooks, _positionUpperBook.z);
    }

    public Book TryGetBook()
    {
        Book book = _textbooks.Pop();
        book.Destroy();
        return book;
    }

    public bool IsEmpty()
    {
        return _textbooks.Count == 0;
    }
}
