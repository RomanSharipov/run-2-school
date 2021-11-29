using System.Collections;
using UnityEngine;

public class MapMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Professor _professor;
    [SerializeField] private float _speedStopping;

    private Coroutine _reduceSpeedJob;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.Translate(new Vector3(0, 0, -Time.deltaTime * _speed));
    }

    public void Stop()
    {
        if (_reduceSpeedJob != null)
        {
            StopCoroutine(_reduceSpeedJob);
            _reduceSpeedJob = null;
        }
        _reduceSpeedJob = StartCoroutine(ReduceSpeed());
    }

    private IEnumerator ReduceSpeed()
    {
        while (_speed != 0)
        {
            _speed = Mathf.MoveTowards(_speed, 0, Time.deltaTime * _speedStopping);
            yield return null;
        }
    }
}
