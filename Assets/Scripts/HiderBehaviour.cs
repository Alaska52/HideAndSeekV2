using Unity.VisualScripting;
using UnityEngine;

// not sure wat are these for

using UnityEngine.AI; // when using navmesh agents

public class HiderBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    
    // for moving
    public Camera cam;
    public Vector3 destinationTOGO;

    // for wandering
    public float range; // radius of sphere
    public Transform centrePoint; // centre of area the agent wants to move around

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //agent.destination = destinationTOGO; // constantly update the sty
        Move();
        Wander();
    }

    public void Move()
    {
        if (Input.GetMouseButtonDown(0)) // check if left mouse button click
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); // take left mouse position to create a ray
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) // send out a ray based on where the player press to get a position
            {
                // move agent
                agent.SetDestination(hit.point); // agent will auto find nearest path there
            }
        }
        //destinationTOGO = agent.destination;
    }

    public void Wander()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) // check if done with his path
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result) // with a navmesh ray cast using a method called Sample Position
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
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
