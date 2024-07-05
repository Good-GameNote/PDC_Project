using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class AgentMover : MonoBehaviour
{
    public Transform target;
    Vector3 point;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        point = new Vector3(28f, 2.4f, 13.5f);


        agent.SetDestination(target.position);
        //MoveToTarget();
    }

    //void MoveToTarget()
    //{
    //    if (target != null)
    //    {
    //        Vector3 targetPosition = target.position;
    //        bool isValidDestination = NavMesh.SamplePosition(targetPosition, out NavMeshHit hit, 1.0f, NavMesh.AllAreas);

    //        if (isValidDestination)
    //        {
    //            agent.SetDestination(hit.position);
    //            agent.isStopped = false;
    //        }
    //        else
    //        {
    //            Debug.Log("Invalid target position");
    //        }
    //    }
    //}

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // 에이전트가 도착했거나 이동 중이 아님
        }
    }
}
