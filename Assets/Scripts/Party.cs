using UnityEngine;

public class Party : MonoBehaviour
{
    [SerializeField] private int _amountReducedBooks;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            for (int i = 0; i < _amountReducedBooks; i++)
            {
                player.Bag.GetBook();
            }
        }
    }
}
