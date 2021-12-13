using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bag : MonoBehaviour
{
    [SerializeField] private ParticleSystem _number;
    [SerializeField] private float _distanceBetweenBooks;
    [SerializeField] private Transform _placeFirstBook;
    [SerializeField] private Vector3 _scaleBookInBag;

    private Stack<Book> _textbooks;
    private Transform _transform;
    private Vector3 _positionUpperBook;

    public event UnityAction<Book> AddedBook;
    public event UnityAction<Book> ReduceBook;

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
        newBook.transform.localPosition = _positionUpperBook;
        newBook.ChangeScaleNewBook(_scaleBookInBag);
        _positionUpperBook = new Vector3(_positionUpperBook.x, _positionUpperBook.y + _distanceBetweenBooks, _positionUpperBook.z);
        AddedBook?.Invoke(book);
    }

    public Book GetBook()
    {
        Book book = _textbooks.Pop();
        book.Destroy();
        _positionUpperBook = new Vector3(_positionUpperBook.x, _positionUpperBook.y - _distanceBetweenBooks, _positionUpperBook.z);
        ReduceBook?.Invoke(book);
        return book;
    }

    public bool IsEmpty()
    {
        return _textbooks.Count == 0;
    }

    public int GetCountBooks(Book typeBook)
    {
        int countBook = 0;

        foreach (var book in _textbooks)
        {
            if (book.GetType() == typeBook.GetType())
            {
                countBook++;
            }
        }
        return countBook;
    }
}
