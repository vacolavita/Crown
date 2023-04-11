using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public Vector3[] pathPoints;
    private NavMeshAgent agent;
    public float waitTime = 3;
    private float timer = 0;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            agent.SetDestination(pathPoints[index]);
            index++;
            timer = waitTime;
            if(index > pathPoints.Length - 1)
            {
                index = 0;
            }
        }
        if (agent.remainingDistance != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0) {
            timer -= Time.deltaTime;
        }
    }
}
