using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InscriptionOnReward : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.Translate(new Vector3(0, Time.deltaTime * _speed, 0));
    }

    private void OnEnable()
    {
        Destroy(gameObject, _lifeTime);
    }
}
