
using UnityEngine;
using UnityEngine.AI;

public class AgentMover : MonoBehaviour
{


    private NavMeshAgent agent;
    [SerializeField]
    Vector3 point;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.SetDestination(point);
    }


}
