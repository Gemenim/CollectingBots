using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Collector : MonoBehaviour
{    
    private bool _isResource = false;
    private bool _isFree = true;
    private Vector3 _target;
    private Vector3 _positionBase;
    private int _resource = 0;

    public Vector3 PositionBase => _positionBase;
    public Vector3 Target => _target;
    public bool IsResource => _isResource;
    public bool IsFree => _isFree;
    public int Resource => _resource;

    private void Start()
    {
        _positionBase = transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if(_isResource && other.TryGetComponent<Base>(out Base warehouse))
        {
            _isResource = false;
            _isFree = true;
            warehouse.TakeResource();
        }
    }

    public void TakePositionBase(Vector3 pisition)
    {
        _positionBase = pisition;
    }

    public void TransferResources(int resources)
    {
        _resource += resources;
    }

    public void TakeTarget(Vector3 target)
    {
        _isFree = false;
        _target = target;
    }

    public void TakeResource()
    {
        _isResource = true;
    }

    public void TransferResource()
    {
        _isFree = true;
        _isResource = false;
    }
}
