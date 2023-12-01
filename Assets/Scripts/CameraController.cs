using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            MoveByX(1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveByX(-1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            MoveByZ(1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveByZ(-1);
        }
    }

    private void MoveByX(float direction)
    {
        Vector3 directionNormaliz = new Vector3(direction, 0, 0).normalized;
        transform.position = transform.position + directionNormaliz * _speed * Time.deltaTime;
    }
    private void MoveByZ(float diraction)
    {
        Vector3 directionNormaliz = new Vector3(0, 0, diraction).normalized;
        transform.position = transform.position + directionNormaliz* _speed * Time.deltaTime;
    }
}
