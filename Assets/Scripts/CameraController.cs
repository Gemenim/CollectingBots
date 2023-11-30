using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _unit = 1;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 direction = new Vector3(_unit, 0, 0).normalized;
            transform.position = transform.position + direction * _speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Vector3 direction = new Vector3(-_unit, 0, 0).normalized;
            transform.position = transform.position + direction * _speed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 direction = new Vector3(0, 0, _unit).normalized;
            transform.position = transform.position + direction * _speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 direction = new Vector3(0, 0, -_unit).normalized;
            transform.position = transform.position + direction * _speed;
        }
    }
}
