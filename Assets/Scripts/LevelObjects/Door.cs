using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Door : MonoBehaviour
{

    public GameObject aimDoor;

    void Start()
    {

        aimDoor.SetActive(false);
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {

            aimDoor.SetActive(true);

        }

    }

}
