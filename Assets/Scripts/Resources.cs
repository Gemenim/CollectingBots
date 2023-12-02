using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Collector>(out Collector collector))
        {
            collector.TakeResource();
            Destroy(gameObject);
        }
    }
}
