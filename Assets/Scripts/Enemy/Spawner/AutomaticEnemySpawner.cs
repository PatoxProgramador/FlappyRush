using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutomaticEnemySpawner : MonoBehaviour
{
    [Header("SpawnLocation")]
    public GameObject[] patrolPoints;
   
    public GameObject ParentObject; //gameobject enemies will spawn inside

    int randomSpot;
    [Header("dont touch")]
    public GameObject[] nextWave;

    [Header("Enemy Spawn variety and numbers")]
    public GameObject[] enemyTypes;
    public int[] enemyQuantity;
    [Header("assign enemy tag to find its determined movepoints path")]
    public string enemySection;
    [Header("Portal lock that unlocked this gameObject")]
    public PortalLocks unlock;//used to enabled this script actions

    [Header("debug")]
    public bool hey;//tells whether the next portal locks should start acting

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
    //finds out the total array size
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
        //type of enemy that will be spawned
        for (int j = 0; j < enemyTypes.Length; j++)
        {
            //adjust where the pointer of the array should be, so the next type of enemies dont replace the current ones
            if (j > 0)
            {

                flag += enemyQuantity[j - 1];

            }
            else
            {

                flag = 0;

            }
            //quantity of enemy spawned of that type
            for (int i = 0; i < enemyQuantity[j]; i++)
            {

                randomSpot = Random.Range(0, patrolPoints.Length);

                GameObject a = Instantiate(enemyTypes[j], patrolPoints[randomSpot].transform.position, Quaternion.identity);

                a.tag = enemySection;

                nextWave[flag + i] = a;

                a.transform.parent = ParentObject.transform;

            }

        }

    }

}
