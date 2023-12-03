using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCollector : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Collector _collector;

    private void Start()
    {
        _collector = GetComponent<Collector>();
    }

    private void FixedUpdate()
    {
        if (_collector.IsFree == false)
        {
            if (_collector.IsResource == false)
                Move(_collector.Target);
            else
                Move(_collector.PositionBase);
        }
    }

    private void Move(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}
