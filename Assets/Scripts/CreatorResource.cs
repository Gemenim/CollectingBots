using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorResource : MonoBehaviour
{
    [SerializeField] private Resources _resources;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _size;

    private float _maxCoordinateX;
    private float _maxCoordinateZ;
    private float _minCoordinateX;
    private float _minCoordinateZ;
    private float _positionY;

    private void Start()
    {
        _maxCoordinateX = transform.position.x + _size;
        _maxCoordinateZ = transform.position.z + _size;
        _minCoordinateX = transform.position.x;
        _minCoordinateZ = transform.position.z;
        _positionY = _resources.transform.localScale.y / 2;

        StartCoroutine(CreateResource());
    }

    private IEnumerator CreateResource()
    {
        while (true)
        {
            float randomPositionX = Random.Range(_minCoordinateX, _maxCoordinateX);
            float randomPositionZ = Random.Range(_maxCoordinateZ, _minCoordinateZ);
            Vector3 position = new Vector3(randomPositionX, _positionY, randomPositionZ);
            Instantiate(_resources, position, Quaternion.identity);
            yield return new WaitForSeconds(_cooldown);
        }
    }
}