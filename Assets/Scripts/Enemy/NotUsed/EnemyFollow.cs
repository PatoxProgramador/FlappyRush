using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    //grabs speed for enemy movement script
    [SerializeField] EnemyMovementFixed patrolChange;
    public bool isShooting;

    public float shootingDistance,startFollowDistance;

    private Transform target;

    void Start()
    {
        //get player location
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        isShooting = false;
        patrolChange = GetComponent<EnemyMovementFixed>();
        
    }

    void Update()
    {

        //decides whether enemyMovement or follow is interactable and at what certain distance
        if (Vector2.Distance(transform.position,target.position) > shootingDistance && Vector2.Distance(transform.position, target.position) < startFollowDistance && CameraZoom.isZoom)
        {

            isShooting = false;
            transform.position = Vector2.MoveTowards(transform.position, target.position, patrolChange.speed * Time.deltaTime);

        }
        else if (Vector2.Distance(transform.position, target.position) <= shootingDistance && CameraZoom.isZoom)
        {

            isShooting = true;

        }
        else
        {

            transform.position = Vector2.MoveTowards(transform.position, patrolChange.moveSpots[patrolChange.randomSpot].position, patrolChange.speed * Time.deltaTime);
            isShooting = false;

        }
          
    }

}
