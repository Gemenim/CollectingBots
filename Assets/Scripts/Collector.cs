using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _positionBase;
    private Vector3 _target;
    private bool _isResource = false;
    private bool _isFree = true;

    public bool IsResource => _isResource;
    public bool IsFree => _isFree;

    private void Start()
    {
        _positionBase = transform.position;
    }

    private void Update()
    {
        if (transform.position == _positionBase && _isResource)
        {
            _isResource = false;
            _isFree = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isFree == false)
        {
            if (_isResource == false)
                transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
            else
                transform.position = Vector3.MoveTowards(transform.position, _positionBase, _speed * Time.deltaTime);
        }
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
