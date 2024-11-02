using System.Collections;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class PortalLocks : MonoBehaviour
{

    public GameObject[] padlock;//enemies

    public GameObject[] key;//Revealing next junk

    [Header("previous portal locks that unlocked this one")]
    public PortalLocks allow;
    
    [Header("spawner of enemies that unlocked this")]
    public AutomaticEnemySpawner spawn;

    [Header("debug")]
    public bool goAhead;

    public bool look;

    void Start()
    {

        goAhead = false;

        foreach (GameObject keychain in key)
        {

            keychain.SetActive(false);

        }

        StartCoroutine(Waiter());

    }

    void Update()
    {

        look = allow.goAhead;

        int j = 0;

        for (int i = 0; i < padlock.Length; i++)
        {
            // checks if everything is null
            if (padlock[i] == null)
            {

                j++;

            }
            if (j == padlock.Length)
            {
                //only if every element is null next step is revealed
                foreach (GameObject lottery in key)
                {

                    lottery.SetActive(true);

                    goAhead = true;

                }

            }//else it restarts the loop again

        }

    }

    IEnumerator Waiter()
    {

        yield return new WaitForSeconds(0.1f);
        //check if the last portal lock was completed
        if (look)
        {
            //if there ar enemies spawned that got to be killed
            if(spawn != null)
            { 

                if (spawn.hey)
                {

                    padlock = new GameObject[spawn.count];

                    for (int i = 0; i < spawn.count; i++)
                    {

                        padlock[i] = spawn.nextWave[i];

                    }

                }

            } 

            StopCoroutine(Waiter());

        }
        else
        {

            StartCoroutine(Waiter());

        }

    }

}
