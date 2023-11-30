using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Collector _collector;
    [SerializeField] private int _countCollectors = 1;

    private Collector[] _collectors;
    private int _countResources = 0;

    public Collector[] Collectors => _collectors;

    private void Awake()
    {
        if (_countCollectors < 1)
            _countCollectors = 1;

        _collectors = new Collector[_countCollectors];

        for (int i = 0; i < _countCollectors; i++)
            _collectors[i] = Instantiate(_collector, transform.position, Quaternion.identity);
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Collector>(out Collector collector))
        {
            if (collector.IsResource)
            {
                _countResources++;
                collector.TransferResource();
            }   
        }
    }
}
