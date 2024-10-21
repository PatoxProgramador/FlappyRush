using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleProjectilesShooting : MonoBehaviour
{
    public GameObject bullet1;
    public GameObject bullet2; 
    public GameObject bullet3; 
    public Transform bulletPos; 
    private float timer;

    public GameObject checkPointPos; 
    public GameObject playerPos; 

    [SerializeField] EnemyFollow allowance; 

    void Start()
    {

        allowance = GetComponent<EnemyFollow>();
        
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
        int randomBullet = Random.Range(1, 4); // Random.Range should have a capital 'R' and an exclusive upper bound

        if (randomBullet == 1)
        {
            Instantiate(bullet1, bulletPos.position, bulletPos.rotation);
        }
        else if (randomBullet == 2)
        {
            Instantiate(bullet2, bulletPos.position, bulletPos.rotation);
        }
        else if (randomBullet == 3)
        {
            Instantiate(bullet3, bulletPos.position, bulletPos.rotation);
        }
    }
}
