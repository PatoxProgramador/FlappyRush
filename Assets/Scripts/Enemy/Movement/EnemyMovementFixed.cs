using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementFixed : MonoBehaviour
{
    [Header("EnemyMovement")]//these headers make public variables in script organised
    //speed of enemy
    public float speed;

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

    void Start()
    {

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
        //decides whether enemyMovement or follow is interactable
        //if (!CameraZoom.isZoom)
        //{

            EnemyFollow();

       // }

    }

    void EnemyFollow()
    {

        //decides whether enemyMovement or follow is interactable and at what certain distance
        if (Vector2.Distance(transform.position, target.position) > shootingDistance && Vector2.Distance(transform.position, target.position) < startFollowDistance && CameraZoom.isZoom)
        {

            isShooting = false;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
        else if (Vector2.Distance(transform.position, target.position) <= shootingDistance && CameraZoom.isZoom)
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

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

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
