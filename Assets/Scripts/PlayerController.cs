using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{

    public Camera cam;

    public NavMeshAgent agent;
    NavMeshAgent myNavMeshAgent;

    public ThirdPersonCharacter character;

    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            agent.enabled = true;

            if (Physics.Raycast(ray, out hit))
            {
                myNavMeshAgent.SetDestination(hit.point);
            }
        }

        if(agent.enabled)
        {
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                character.Move(agent.desiredVelocity, false, false);
            }
            else
            {
                character.Move(Vector3.zero, false, false);
            }
        }
    }
}