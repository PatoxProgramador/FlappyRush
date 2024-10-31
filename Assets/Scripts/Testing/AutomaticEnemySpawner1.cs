using System.Collections;
using UnityEngine;

public class AutomaticEnemySpawner1 : MonoBehaviour
{

    public GameObject[] patrolPoints;
    public GameObject[] nextWave;

    int randomSpot;

    public string waveName;
    
    void Start()
    {

        StartCoroutine(Creator());

    }

    void Update()
    {

    }

    IEnumerator Creator()
    {

        yield return new WaitForSeconds(0.1f);

        if (AutomaticEnemySpawner.hey)
        {

            for (int i = 0; i < nextWave.Length; i++)
            {

                randomSpot = Random.Range(0, 3);

                GameObject a = Instantiate(nextWave[i], patrolPoints[randomSpot].transform.position, Quaternion.identity);

                a.tag = waveName;

                nextWave[i] = a;

            }

            nextWave = GameObject.FindGameObjectsWithTag(waveName);

            StopCoroutine(Creator());

        }
        else
        {

            StartCoroutine(Creator());

        }
        

    }

}
