using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coordinator : MonoBehaviour
{
    private Base _base;
    private CreatorResource _creatorResource;
    private List<Resources> _resources;

    private void Start()
    {
        _base = GetComponent<Base>();
        _creatorResource = GameObject.FindAnyObjectByType<Terrain>().GetComponentInChildren<CreatorResource>();
    }

    private void Update()
    {
        _resources = _creatorResource.ResourcesList;

        if (_resources.Count > 0)
        {
            foreach (Collector collector in _base.Collectors)
            {
                if (collector.IsFree)
                {
                    foreach (Resources resources in _resources)
                    {
                        if (resources.IsFound == false)
                        {
                            collector.TakeTarget(resources.transform.position);
                            resources.ChangeStatus();
                            break;
                        }
                    }
                }
            }
        }
    }
}
