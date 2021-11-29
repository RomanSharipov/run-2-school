using UnityEngine;

public class Book : MonoBehaviour
{

    private Transform _transform;
    private BoxCollider _boxCollider;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.TakeBook(this);
            Destroy();
        }
    }

    public void ChangeScaleNewBook(Vector3 newScale)
    {
        _transform.localScale = newScale;
    }

    public void SwitchOffBoxCollider()
    {
        _boxCollider.enabled = false;}

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
