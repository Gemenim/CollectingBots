using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Collector>(out Collector collector) && collector.IsResource == false)
        {
            collector.TakeResource();
            Destroy(gameObject);
        }
    }
}
