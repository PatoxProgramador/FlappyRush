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
    //public GameObject []moveSpots;
    public List<GameObject> moveSpots = new List<GameObject>(); 

    public int randomSpot;

    public float pointDistance;

    [SerializeField]int arraySize;

    public string[] patrolTag;

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

        AutomaticSpawnerName();

        arraySize = 0;
        TagControl();

        //get location
        randomSpot = Random.Range(0,arraySize);

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

        agent.SetDestination(moveSpots[randomSpot].transform.position);

        //reach the position
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].transform.position) < pointDistance)
        {
            //time for enemy to move
            if (waitTime <= 0)
            {
                //new target
                randomSpot = Random.Range(0, arraySize);

                waitTime = startWaitTime;

            }
            else
            {

                waitTime -= Time.deltaTime;

            }

        }

    }
    //finds all patrol spot that has to walk over
    void TagControl()
    {

        for (int i = 0; i < patrolTag.Length; i++)
        {

            GameObject[] movingSpots = GameObject.FindGameObjectsWithTag(patrolTag[i]);

            for (int j = 0; j < movingSpots.Length; j++)
            {

                moveSpots.Add(movingSpots[j]);

                arraySize++;

            }

        }

    }

    void AutomaticSpawnerName()
    {

        switch (gameObject.tag)
        {

            case "EnemySquareLeft":

                patrolTag = new string[2];

                patrolTag[0] = "LeftSquareMoveSpot";
                patrolTag[1] = "CenterLeftSquareMoveSpot";

            break;

            case "EnemySquareRight":

                patrolTag = new string[2];

                patrolTag[0] = "RightSquareMoveSpot";
                patrolTag[1] = "CenterRightSquareMoveSpot";

            break;

            case "EnemySquareBottom":

                patrolTag = new string[2];

                patrolTag[0] = "BottomSquareMoveSpot";
                patrolTag[1] = "CenterBottomSquareMoveSpot";

            break;

            case "EnemySquareTopLeft":

                patrolTag = new string[2];

                patrolTag[0] = "TopLeftSquareMoveSpot";
                patrolTag[1] = "CenterLeftSquareMoveSpot";

            break;

            case "EnemySquareTopRight":

                patrolTag = new string[2];

                patrolTag[0] = "TopRightSquareMoveSpot";
                patrolTag[1] = "CenterRightSquareMoveSpot";

            break;

            case "EnemyLowerLeftTriangle":

                patrolTag = new string[1];

                patrolTag[0] = "LowerLeftTriangleMoveSpot";

            break;

            case "EnemyLowerRightTriangle":

                patrolTag = new string[1];

                patrolTag[0] = "LowerRightTriangleMoveSpot";

            break;

            case "EnemyUpperLeftTriangleLowerHalf":

                patrolTag = new string[1];

                patrolTag[0] = "UpperLeftTriangleLowerHalf";

            break;

            case "EnemyUpperRightTriangleLowerHalf":

                patrolTag = new string[1];

                patrolTag[0] = "UpperRightTriangleLowerHalf";

            break;

            case "EnemyUpperLeftTriangleUpperHalf":

                patrolTag = new string[1];

                patrolTag[0] = "UpperLeftTriangleUpperHalf";

            break;

            case "EnemyUpperRightTriangleUpperHalf":

                patrolTag = new string[1];

                patrolTag[0] = "UpperRightTriangleUpperHalf";

            break;

        }

        gameObject.tag = "enemy";

    }

}
