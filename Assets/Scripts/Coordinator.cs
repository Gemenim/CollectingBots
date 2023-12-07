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
        StartCoroutine(Coordinate());
    }

    private IEnumerator Coordinate()
    {
        while (true) 
        {
            _resources = _creatorResource.ResourcesQueuet;

            if (_base.IsFlag && _base.CoutnResources == 5)
            {
                foreach (Collector collector in _base.Collectors)
                {
                    if (collector.IsFree)
                    {
                        collector.TransferResources(5);
                        collector.TakeTarget(_base.targetFlag.transform.position);
                        break;
                    }
                }
            }
            else if (_resources.Count > 0)
            {
                foreach (Collector collector in _base.Collectors)
                {
                    if (collector.IsFree)
                    {
                        Resources resources = _resources.Dequeue();
                        if (resources == null)
                            break;
                        collector.TakeTarget(resources.transform.position);
                        break;
                    }
                }
            }

            yield return new WaitForFixedUpdate();
        }
    }
}
