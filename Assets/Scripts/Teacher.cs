using UnityEngine;

public class Teacher : MonoBehaviour
{
    [SerializeField] private Book[] _booksReward;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            foreach (var book in _booksReward)
            {
                player.Bag.PutInside(book);
            }
        }
    }
}
