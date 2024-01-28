using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
using System;

public class TrashNavDestinations : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    public float speed, maxSpeed, minSpeed;
    public Vector3 currentDestination;
    public int destinationCounter;
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
        navMeshAgent.updateRotation = false;
        navMeshAgent.speed = speed; 
        navMeshAgent.SetDestination(destinations[destinationCounter].transform.position);
        initialRotation = transform.rotation;
        //currentDestination = destinations[destinationCounter].transform.position;
        destinationCounter++;
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.velocity != Vector3.zero)
        {
            // Apply the initial rotation
            transform.rotation = initialRotation;
        }
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if(destinationCounter != destinations.Length)
            {
                navMeshAgent.SetDestination(destinations[destinationCounter].transform.position);
                destinationCounter++;
            }
        }
        
    }
}
