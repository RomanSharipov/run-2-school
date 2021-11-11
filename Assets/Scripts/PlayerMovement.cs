using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        _transform.Translate(new Vector3(0, 0, Time.deltaTime * _speed));
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            transform.position = new Vector3(0, 0, 0);
           
        }
    }

}
