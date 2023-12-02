using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coordinator : MonoBehaviour
{
    private Base _base;
    private CreatorResource _creatorResource;
    private Queue<Resources> _resources;

    private void Start()
    {
        _base = GetComponent<Base>();
        _creatorResource = GameObject.FindAnyObjectByType<Terrain>().GetComponentInChildren<CreatorResource>();
    }

    private void FixedUpdate()
    {
        _resources = _creatorResource.ResourcesQueuet;

        if (_resources.Count > 0)
        {
            foreach (Collector collector in _base.Collectors)
            {
                if (collector.IsFree)
                {
                    Resources resources = _resources.Dequeue();
                    collector.TakeTarget(resources.transform.position);
                    break;
                }
            }
        }
    }
}
