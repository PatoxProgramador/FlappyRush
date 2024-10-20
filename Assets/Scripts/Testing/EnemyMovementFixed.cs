using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementFixed : MonoBehaviour
{

    public float speed;

    private float waitTime;
    public float startWaitTime;

    public Transform []moveSpots;
    private int randomSpot;
    //patrol borders
    public float maxX,minX,minY,maxY;
    
    void Start()
    {

        waitTime = startWaitTime;

        //get location
        randomSpot = Random.Range(0,moveSpots.Length);
        
    }

    void Update()
    {
        //decides whether enemyMovement or follow is interactable
        if (!CameraZoom.isZoom)
        {

            //moving towards location
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
            //reach the position
            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
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

}
