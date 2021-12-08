using UnityEngine;

public class GeneratorStair : MonoBehaviour
{
    [SerializeField] private Transform _placeNewStair;
    [SerializeField] private Player _player;
    [SerializeField] private float _delay;
    [SerializeField] private Vector3 _scaleOneStair;
    [SerializeField] private MapMovement _map;

    private float _lastCreateStairTime;

    private void CreateOneStepStair()
    {
        Book book = _player.Bag.GetBook();
        Book newStair = Instantiate(book, _placeNewStair.position, _placeNewStair.rotation);
        newStair.transform.SetParent(_map.transform,true);
        newStair.SwitchOffBoxCollider();
        newStair.ChangeScaleNewBook(_scaleOneStair);
    }

    private void OnEnable()
    {
        _player.PlayerMovement.ClimbedStairs += OnTryCreateStair;
    }

    private void OnDisable()
    {
        _player.PlayerMovement.ClimbedStairs -= OnTryCreateStair;
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
