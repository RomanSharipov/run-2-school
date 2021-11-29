using UnityEngine;

public class Teacher : MonoBehaviour
{
    [SerializeField] private Book[] _booksReward;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bag bag))
        {
            foreach (var book in _booksReward)
            {
                bag.PutInside(book);
            }
        }
    }
}
