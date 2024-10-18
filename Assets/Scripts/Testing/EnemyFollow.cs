using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    //grabs speed for enemy movement script
    EnemyMovement patrolChange;

    public float shootingDistance,startFollowDistance;

    private Transform target;

    void Start()
    {
        //get player location
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        patrolChange = GetComponent<EnemyMovement>();
        
    }

    void Update()
    {

        //decides whether enemyMovement or follow is interactable and at what certain distance
        if (Vector2.Distance(transform.position,target.position) > shootingDistance && Vector2.Distance(transform.position, target.position) < startFollowDistance && CameraZoom.isZoom)
        {

            EnemyShooting1.isShooting = false;
            transform.position = Vector2.MoveTowards(transform.position, target.position, patrolChange.speed * Time.deltaTime);

        }
        else if (Vector2.Distance(transform.position, target.position) <= shootingDistance && CameraZoom.isZoom)
        {

            EnemyShooting1.isShooting = true;

        }
        else
        {

            EnemyShooting1.isShooting= false;

        }
          
    }

}
