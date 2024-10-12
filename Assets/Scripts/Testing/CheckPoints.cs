using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{

    public GameObject[] unlockable;

    void Start()
    {

        for(int i = 0; i < unlockable.Length; i++)
        {

            unlockable[i].SetActive(false);

        }
           
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            for (int i = 0; i < unlockable.Length; i++)
            {

                unlockable[i].SetActive(true);

            }

        }
        
    }

}
