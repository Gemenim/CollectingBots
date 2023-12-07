using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatorResource : MonoBehaviour
{
    [SerializeField] private Resources _resources;
    [SerializeField] private float _cooldown;
    [SerializeField] private int _maxCountResources = 5;
    [SerializeField] private float _size;

    private Queue<Resources> _resourcesQueuet = new Queue<Resources>();
    private WaitForSeconds _delay;
    private float _maxCoordinateX;
    private float _maxCoordinateZ;
    private float _minCoordinateX;
    private float _minCoordinateZ;
    private float _positionY;

    public Queue<Resources> ResourcesQueuet => _resourcesQueuet;

    private void Awake()
    {
        if (_maxCountResources <= 0)
            _maxCountResources = 5;
    }

    private void Start()
    {
        _maxCoordinateX = transform.position.x + _size;
        _maxCoordinateZ = transform.position.z + _size;
        _minCoordinateX = transform.position.x;
        _minCoordinateZ = transform.position.z;
        _positionY = _resources.transform.localScale.y / 2;
        _delay = new WaitForSeconds(_cooldown);

        StartCoroutine(CreateResource());
    }

    private IEnumerator CreateResource()
    {
        while (true)
        {
            if (_resourcesQueuet.Count < _maxCountResources)
            {
                float randomPositionX = Random.Range(_minCoordinateX, _maxCoordinateX);
                float randomPositionZ = Random.Range(_maxCoordinateZ, _minCoordinateZ);
                Vector3 position = new Vector3(randomPositionX, _positionY, randomPositionZ);
                _resourcesQueuet.Enqueue(Instantiate(_resources, position, Quaternion.identity));
            }
            yield return _delay;
        }
    }
}
