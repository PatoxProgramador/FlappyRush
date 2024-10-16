using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Firing : MonoBehaviour
{

    [SerializeField]
    private GameObject bulletSpawnPointRight;
    [SerializeField]
    private GameObject bulletSpawnPointLeft;

    [SerializeField] private GameObject bulletPrefab;
    [Range(0.1f, 10f)]
    [SerializeField]
    private float fireRate = 1f;

    private float fireTimer = 0f;

    [Range(1f, 100f)]
    [SerializeField]
    private float recoil = 30;
    [Range(0f, 1f)]
    public float firingSpeed;

    // Update is called once per frame
    public float FireAndReturnRecoil()
    {

        if (Input.GetMouseButton(0) && fireTimer <= firingSpeed)
        {

            return this.shoot();

        }
        else
        {

            fireTimer -= Time.fixedDeltaTime;

        }
        return 0;

    }

    private float shoot()
    {

        if (!this.transform.parent.GetComponent<SpriteRenderer>().flipY)
        {

            Instantiate(bulletPrefab, this.bulletSpawnPointRight.transform.position, this.bulletSpawnPointRight.transform.rotation);

        }
        else
        {

            Instantiate(bulletPrefab, this.bulletSpawnPointLeft.transform.position, this.bulletSpawnPointLeft.transform.rotation);

        }

        this.fireTimer = this.fireRate;
        return this.recoil;

    }

}
