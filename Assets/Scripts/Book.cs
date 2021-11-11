using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.TakeBook(this);
            Destroy(gameObject);
        }
    }

    public void Read()
    {
        Debug.Log("READ");
    }
}
