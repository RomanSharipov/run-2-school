using UnityEngine;

public class GeneratorStair : MonoBehaviour
{
    [SerializeField] private Transform _placeNewStair;
    [SerializeField] private Bag _bag;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _delay;
    [SerializeField] private Vector3 _scaleOneStair;
    [SerializeField] private MapMovement _map;

    private float _lastCreateStairTime;

    private void CreateOneStepStair()
    {
        Book book = _bag.GetBook();
        Book newStair = Instantiate(book, _placeNewStair.position, _placeNewStair.rotation);
        newStair.transform.SetParent(_map.transform,true);
        newStair.ChangeScaleNewBook(_scaleOneStair);
        newStair.SwitchOffBoxCollider();
    }

    private void OnEnable()
    {
        _playerMovement.ClimbedStairs += OnTryCreateStair;
    }

    private void OnDisable()
    {
        _playerMovement.ClimbedStairs -= OnTryCreateStair;
    }

    private void OnTryCreateStair()
    {
        if (_lastCreateStairTime <= 0)
        {
            CreateOneStepStair();
            _lastCreateStairTime = _delay;
        }
        _lastCreateStairTime -= Time.deltaTime;
    }
}
