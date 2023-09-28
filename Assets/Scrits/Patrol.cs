using UnityEngine;

public class Patrol : MonoBehaviour
{

    public Transform[] waypoints;
    private int _currentWaypointIndex = 0;
    private float _speed = 35f;


    private void Update()
    {

        Transform wp = waypoints[_currentWaypointIndex];
        if (Vector3.Distance(transform.position, wp.position) < 0.01f)
        {
            transform.position = wp.position;
            _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wp.position, _speed * Time.deltaTime);
        }
    }

}
