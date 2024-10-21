using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementFixed : MonoBehaviour
{

    public float speed;

    private float waitTime;
    public float startWaitTime;

    public Transform []moveSpots;
    public int randomSpot;
    
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

}
