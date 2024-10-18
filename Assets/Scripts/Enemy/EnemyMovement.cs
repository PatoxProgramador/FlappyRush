using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed;

    private float waitTime;
    public float startWaitTime;

    public Transform moveSpot;
    //patrol borders
    public float maxX,minX,minY,maxY;
    
    void Start()
    {

        waitTime = startWaitTime;
        //get location
        moveSpot.position = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));

    }

    void Update()
    {
        //decides whether enemyMovement or follow is interactable
        if (!CameraZoom.isZoom)
        {

            //moving towards location
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
            //reach the position
            if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
            {
                //time for enemy to move
                if (waitTime <= 0)
                {
                    //new target
                    moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

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
