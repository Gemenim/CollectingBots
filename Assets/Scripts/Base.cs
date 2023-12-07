using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Collector _collector;
    [SerializeField] private int _countCollectors = 1;
    [SerializeField] private int _limitBots = 5;
    [SerializeField] private Flag _flag;
    [SerializeField] private float _size;

    private List<Collector> _collectors = new List<Collector>();
    private Flag _targetFlag;
    private int _countResources = 0;
    private bool _isFlag = false;
    private bool _isExpectClickJob = false;

    private float _maxCoordinateX;
    private float _maxCoordinateZ;
    private float _minCoordinateX;
    private float _minCoordinateZ;

    public List<Collector> Collectors => _collectors;
    public int CoutnResources => _countResources;
    public Flag targetFlag => _targetFlag;
    public bool IsFlag => _isFlag;

    private void Awake()
    {
        if (_countCollectors < 0)
            _countCollectors = 0;

        if (_limitBots <= 0)
            _limitBots = 1;

        for (int i = 0; i < _countCollectors; i++)
            _collectors.Add(Instantiate(_collector, transform.position, Quaternion.identity));

        _maxCoordinateX = 0 + _size;
        _maxCoordinateZ = 0 + _size;
        _minCoordinateX = 0;
        _minCoordinateZ = 0;
    }

    private void Update()
    {
        if (_isFlag)
        {
            if (_countResources >= 5)
            {
                _countResources -= 5;
                _isFlag = false;
            }
        }
        else if (_countResources == 3 && _collectors.Count < _limitBots)
        {
            CreatNewBot();
            _countResources -= 3;
        }
    }

    private void OnMouseDown()
    {
        StartExpectClick();
    }

    private IEnumerator ExpectClick()
    {
        _isExpectClickJob = true;

        while (_isFlag == false)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Vector3 mousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 flagPosition = new Vector3(mousPosition.x, _flag.transform.lossyScale.y / 2, mousPosition.z);
                CheckPositionFlag(flagPosition, out flagPosition);
                _targetFlag = Instantiate(_flag, flagPosition, Quaternion.identity);
                _isFlag = true;
                _isExpectClickJob = false;
            }

            yield return null;
        }
    }

    private void CheckPositionFlag(Vector3 position, out Vector3 newPosition)
    {
        newPosition = position;

        if (position.x > _maxCoordinateX)
            newPosition = new Vector3(_maxCoordinateX, position.y, position.z);
        else if (position.x < _minCoordinateX)
            newPosition = new Vector3(_minCoordinateX, position.y, position.z);

        if (position.z > _maxCoordinateZ)
            newPosition = new Vector3(position.x, position.y, _maxCoordinateZ);
        else if (position.z < _minCoordinateZ)
            newPosition = new Vector3(position.x, position.y, _minCoordinateZ);
    }

    private void StartExpectClick()
    {
        if (_isExpectClickJob == false)
        {
            if (_targetFlag != null)
            {
                _targetFlag.Remove();
                _isFlag = false;
            }

            var jobExpectClick = StartCoroutine(ExpectClick());
        }
    }

    public void TakeCollector(Collector collector)
    {
        _collectors.Add(collector);
    }

    public void RemoveCollector(Collector collector)
    {
        _collectors.Remove(collector);
    }

    public void TakeResource()
    {
        _countResources++;
    }

    private void CreatNewBot()
    {
        _collectors.Add(Instantiate(_collector, transform.position, Quaternion.identity));
    }
}
