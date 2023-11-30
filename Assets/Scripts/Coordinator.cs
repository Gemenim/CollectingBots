using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinator : MonoBehaviour
{
    private Base _base;
    private Resources[] _resources;

    private void Start()
    {
        _base = GetComponent<Base>();
    }

    private void Update()
    {
        _resources = GameObject.FindObjectsOfType<Resources>();

        if (_resources.Length > 0)
        {
            foreach (Resources resources in _resources)
            {
                if (resources.IsFound == false)
                {
                    foreach (Collector collector in _base.Collectors)
                    {
                        if (collector.IsFree)
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
