using UnityEngine;
using UnityEngine.UI;

public abstract class Book : MonoBehaviour
{
    [SerializeField] private Color _colorBar;
    [SerializeField] private string _symbol;
    [SerializeField] private ParticleSystem _paperExplosionTemplate;

    private Transform _transform;
    private BoxCollider _boxCollider;

    public Color ColorBar => _colorBar;
    public string Symbol => _symbol;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Instantiate(_paperExplosionTemplate, _transform.position, _transform.rotation);
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
        _boxCollider.enabled = false;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
