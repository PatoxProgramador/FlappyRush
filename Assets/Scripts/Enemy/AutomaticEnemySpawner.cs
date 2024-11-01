using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutomaticEnemySpawner : MonoBehaviour
{

    public GameObject[] patrolPoints;

    public GameObject[] nextWave;

    int randomSpot;

    public string enemySection;

    public PortalLocks unlock;

    public GameObject ParentObject;

    public bool hey;

    void Start()
    {

        hey = false;

    }

    void Update()
    {

        if (unlock.goAhead && !hey)
        {

            for (int i = 0; i < nextWave.Length; i++)
            {

                randomSpot = Random.Range(0, patrolPoints.Length);

                GameObject a = Instantiate(nextWave[i], patrolPoints[randomSpot].transform.position, Quaternion.identity);

                a.tag = enemySection;

                nextWave[i] = a;

                a.transform.parent = ParentObject.transform;

            }

            hey = true;

        }

    }

}
