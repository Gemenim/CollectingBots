using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    private bool _isFound = false;

    public bool IsFound => _isFound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Collector>(out Collector collector))
        {
            collector.TakeResource();
            Destroy(gameObject);
        }
    }

    public void ChangeStatus()
    {
        _isFound = true;
    }
}
