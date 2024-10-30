using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementFixed : MonoBehaviour
{
    [Header("EnemyMovement")]//these headers make public variables in script organised
    
    private float waitTime;
    public float startWaitTime;
    [Header("Patrol")]
    //fixed transform position path
    public Transform []moveSpots;
    public int randomSpot;

    [Header("EnemyFollow")] 
    public bool isShooting;

    public float shootingDistance, startFollowDistance;

    private Transform target;
    //enemy automatic displacement
    NavMeshAgent agent;

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        waitTime = startWaitTime;

        //get location
        randomSpot = Random.Range(0,moveSpots.Length);

        //EnemyFollow
        //get player location
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        isShooting = false;

    }

    void Update()
    {
 
            EnemyFollow();

    }

    void EnemyFollow()
    {

        //decides whether enemyMovement or follow is interactable and at what certain distance
        if (Vector2.Distance(transform.position, target.position) > shootingDistance && Vector2.Distance(transform.position, target.position) < startFollowDistance)
        {

            isShooting = false;
            
            agent.SetDestination(target.position);

        }
        else if (Vector2.Distance(transform.position, target.position) <= shootingDistance)
        {

            isShooting = true;

        }
        else
        {

            isShooting = false;
           
            EnemyPatrol();

        }

    }
    void EnemyPatrol()
    {

        agent.SetDestination(moveSpots[randomSpot].position);

        //reach the position
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.5f)
        {
            //time for enemy to move
            if (waitTime <= 0)
            {
                //new target
                randomSpot = Random.Range(0, moveSpots.Length);

                waitTime = startWaitTime;

            }
            else
            {

                waitTime -= Time.deltaTime;

            }

        }

    }

}
