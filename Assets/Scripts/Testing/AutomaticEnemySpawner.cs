using UnityEngine;
using UnityEngine.SceneManagement;

public class AutomaticEnemySpawner : MonoBehaviour
{

    public GameObject[] patrolPoints;

    public GameObject[] nextWave;

    int randomSpot;

    public static bool hey;
    
    void Start()
    {

        hey = false;

        for (int i = 0; i< nextWave.Length;i++)
        {

            randomSpot = Random.Range(0,3);

            Instantiate(nextWave[i], patrolPoints[randomSpot].transform.position, Quaternion.identity);

            nextWave[i] = null;

        }

            nextWave = GameObject.FindGameObjectsWithTag("enemy");

    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {

            for (int i = 0; i < nextWave.Length; i++)
            {

                Destroy(nextWave[i]);

            }

            hey = true;

        }

    }

}
