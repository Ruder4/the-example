using UnityEngine;

public class Patrol : MonoBehaviour
{
    private float timeRemaining = 300;
    private bool hasTimeRemaining = true;

    public Transform[] waypoints;
    private int _currentWaypointIndex = 0;
    private float _speed = 25f;

    private float _waitTime = 0f; // in seconds
    private float _waitCounter = 0f;
    private bool _waiting = false;

    private void Update()
    {
        if(hasTimeRemaining == true) 
        { 
            timeRemaining -= Time.deltaTime;
        }
        
        if(Mathf.FloorToInt(timeRemaining / 60) <= 1)
        {
            _speed = 35f;
            hasTimeRemaining = false;
        }
       
        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter < _waitTime)
                return;
            _waiting = false;
        }
        
        Transform wp = waypoints[_currentWaypointIndex];
        if (Vector3.Distance(transform.position, wp.position) < 0.01f)
        {
            transform.position = wp.position;
            _waitCounter = 0f;
            _waiting = true;

            _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wp.position, _speed * Time.deltaTime);
        }
    }

}
