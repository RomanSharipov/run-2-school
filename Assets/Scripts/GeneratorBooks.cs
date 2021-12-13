using UnityEngine;

public class GeneratorBooks : MonoBehaviour
{
    private const float GroungPositionY = 22.31236f;

    [SerializeField] private GameObject[] _items;
    [SerializeField] private int _lengthCountItems;
    [SerializeField] private int _widthCountItems;
    [SerializeField] private int _stepWidth;
    [SerializeField] private int _stepLength;
    [SerializeField] private MapMovement _map;
    [SerializeField] private Transform _startSpawnPoint;

    private Vector3 _spawnPoint = new Vector3();
    private float _spawnPointX;
    private float _spawnPointZ;
    private int _randomIndex;

    private void Start()
    {
        for (int i = 0; i < _widthCountItems; i++)
        {
            for (int j = 0; j < _lengthCountItems; j++)
            {
                _spawnPointX = (_startSpawnPoint.localPosition.x + i) + i * _stepWidth; 
                _spawnPointZ = (_startSpawnPoint.localPosition.z + j) + j * _stepLength; 
                _spawnPoint = new Vector3(_spawnPointX, GroungPositionY, _spawnPointZ); 

                _randomIndex = Random.Range(0, _items.Length);

                var newBook = Instantiate(_items[_randomIndex]);

                newBook.transform.SetParent(_map.transform, true);
                newBook.transform.localPosition = _spawnPoint;
            }
        }
    }
}
