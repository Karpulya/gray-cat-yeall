using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayMyAnimation : MonoBehaviour
{
    private FunctionTimer functionTimer;
    [SerializeField] 
    private Animator myAnimatonController;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Transform _bedPoint;
    [SerializeField]
    private Transform _bedPoinEnd;

    private Transform _prisonerTransform;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimatonController.SetBool("Sleep", true);
            agent.enabled = false;
            other.transform.eulerAngles = new Vector3(0, -90, 0);
            _prisonerTransform = other.transform;
            Invoke("SetPrisonerToThePoint", 2f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agent.enabled = false;
            myAnimatonController.SetBool("Sleep", false);
            myAnimatonController.SetBool("WakeUp", true);
            
            other.transform.eulerAngles = new Vector3(0, -90, 0);
            _prisonerTransform = other.transform;
            Invoke("SetPrisonerToTheEndPoint", 1f);
        }
    }
    private void SetPrisonerToThePoint()
    {
        _prisonerTransform.position = _bedPoint.position;

    }
   
    private void SetPrisonerToTheEndPoint()
    {
        agent.enabled = true;
        _prisonerTransform.position = _bedPoinEnd.position;
    }
}
