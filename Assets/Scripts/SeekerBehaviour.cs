using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.GameCenter;

public class SeekerBehaviour : MonoBehaviour
{
    [SerializeField]
    public NavMeshAgent _navAgent;

    public Transform _target;

    public float range; // radius of sphere
    public Transform centrePoint; // centre of area the agent wants to move around

    public Transform target;
    public Action _currentState; // for fsm

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentState = Patrol;
    }



    // Update is called once per frame
    void Update()
    {
        //Patrol();
        if (_currentState != null) _currentState();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    // movement code
    public void Patrol()
    {
        if (_navAgent.remainingDistance <= _navAgent.stoppingDistance) // check if done with his path
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                _navAgent.SetDestination(point);
            }
        }


        //if (0 == 0)
        //{

        //}

        //int myVar =
        //if (true)
        //{

        //}
        //else if (true)
        //{

        //}
        //else
        //{

        //}

        //int somevalue = 0;
        //switch (somevalue)
        //{
        //    case 0: break;
        //    case 1: break;
        //    case 2: break;
        //    default:
        //        break;
        //}


        //bool isSeePlayer = false;
        //if (isSeePlayer) {
        //    _currentState = Chase;
        //}
    }

    public void Chase()
    {
        // if in line of sight
        //if (target) // TODO: auto assign target based on FOV instead of hardcode
        //{

        //}
        // set seeker position to hider position
        // .. if line of side break
        // .. go to last known
        float distance = Vector3.Distance(transform.position, _target.transform.position);

        Vector3 chasePoint = Vector3.zero;
        // compute your chase point

        bool isLoseSightOfPlayer = false;
        if (isLoseSightOfPlayer)
        {
            _currentState = Patrol;
        }

    }

    // utility code
    // gets random point from a sphere
    bool RandomPoint(Vector3 center, float range, out Vector3 result) // with a navmesh ray cast using a method called Sample Position
    {
        Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
