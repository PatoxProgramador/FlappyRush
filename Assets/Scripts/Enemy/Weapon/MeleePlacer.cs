using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleePlacer : MonoBehaviour
{
    public GameObject rotationmelee;
    public GameObject bullet;
    public Transform bulletPos;
    private float timer;
    [SerializeField] EnemyMovementFixed allowance;

    void Start()
    {
        rotationmelee = GameObject.Find("Rotating");
        allowance = GetComponent<EnemyMovementFixed>();

    }

    void Update()
    {

        if (allowance.isShooting)
        {

                timer += Time.deltaTime;
                if (timer > 1.5f)
                {
                    timer = 0;
                    shoot();
                }

        }   

    }

    void shoot ()
    {
    GameObject meleeAttack = Instantiate(bullet, bulletPos.position, rotationmelee.transform.rotation * Quaternion.Euler(0, 0, 80));

    meleeAttack.transform.parent = transform;

    Destroy(meleeAttack, 0.5f);

    }

}
