using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting1 : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPos;
    private float timer;

    [SerializeField] EnemyMovementFixed allowance;

    void Start()
    {

        allowance = GetComponent<EnemyMovementFixed>();

    }

    void Update()
    {

        if (allowance.isShooting)
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
