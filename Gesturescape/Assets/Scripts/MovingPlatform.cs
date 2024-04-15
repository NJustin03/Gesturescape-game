using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private WaypointPath _waypointPath;

    [SerializeField]
    private PlatformSettings _speed;

    private int _targetWaypointIndex;

    private Transform _previousWaypoint;
    private Transform _targetWaypoint;

    private float _timeToWaypoint;
    private float _elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        TargetNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        float elapsedPercentage = _elapsedTime / _timeToWaypoint;

        //Allows for platforms to move smoothly when reaching a waypoint
        //elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);

        transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPercentage);

        if(elapsedPercentage >= 1 )
        {
            TargetNextWaypoint();
        }
    }

    private void TargetNextWaypoint()
    {
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

        _elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed.getSpeed();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
