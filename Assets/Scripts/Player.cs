using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Bag _bag;

    public void TakeBook(Book book)
    {
        _bag.PutInside(book);
    }
}
