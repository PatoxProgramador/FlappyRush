using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting1 : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;

    public GameObject checkPointPos;
    public GameObject playerPos;

    void Start()
    {

    }

    void Update()
    {

        float distanceCheck = Vector2.Distance(checkPointPos.transform.position, gameObject.transform.position);
        float distancePlayer = Vector2.Distance(playerPos.transform.position, gameObject.transform.position);

        if (distancePlayer < distanceCheck)
        {

            timer += Time.deltaTime;
            if (timer > 1f)
            {
                timer = 0;
                shoot();
            }

        }
        

    }

    void shoot ()
    {

        Instantiate (bullet, bulletPos.position, Quaternion.identity);

    }

}
