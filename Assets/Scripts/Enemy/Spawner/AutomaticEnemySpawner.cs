using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutomaticEnemySpawner : MonoBehaviour
{

    public GameObject[] patrolPoints;

    public GameObject[] nextWave;

    public GameObject[] enemyTypes;
    public int[] enemyQuantity;

    int randomSpot;

    public string enemySection;

    public PortalLocks unlock;

    public GameObject ParentObject;

    public bool hey;

    public int count;

    void Start()
    {   

        hey = false;

    }

    void Update()
    {

        if (unlock.goAhead && !hey)
        {

            EnemySpawner();

            hey = true;

        }

    }

    void LengthCreator()
    {

        count = 0;

        for (int i = 0; i < enemyQuantity.Length; i++)
        {

            count += enemyQuantity[i];

        }

        nextWave = new GameObject[count];

    }
    void EnemySpawner()
    {

        LengthCreator();

        int flag = 0;

        for (int j = 0; j < enemyTypes.Length; j++)
        {

            for (int i = 0; i < enemyQuantity[j]; i++)
            {

                randomSpot = Random.Range(0, patrolPoints.Length);

                GameObject a = Instantiate(enemyTypes[j], patrolPoints[randomSpot].transform.position, Quaternion.identity);

                a.tag = enemySection;

                if (j > 0)
                {

                    flag += enemyQuantity[j-1];

                }
                else
                {

                    flag = 0;

                }

                nextWave[i + flag] = a;

                a.transform.parent = ParentObject.transform;

                flag += enemyQuantity[j];

            } 

        }

    }

}
