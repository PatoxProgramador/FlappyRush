using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleProjectilesShooting : MonoBehaviour
{

    public GameObject[] bullets;

    public Transform bulletPos; 

    private float timer;

    public GameObject checkPointPos; 
    public GameObject playerPos; 

    [SerializeField] EnemyMovementFixed allowance; 

    void Start()
    {

        allowance = GetComponent<EnemyMovementFixed>();
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1f && allowance.isShooting)
        {
            timer = 0; 
            Shoot();   
        }
    }

    void Shoot()
    {
        int randomBullet = Random.Range(1, bullets.Length); // Random.Range should have a capital 'R' and an exclusive upper bound

        for (int i = 0; i < bullets.Length; i++)
        {

            if (randomBullet == i)
            {

                Instantiate(bullets[i], bulletPos.position, bulletPos.rotation);

            }

        }
       
    }
}
