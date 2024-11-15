using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraChange : MonoBehaviour
{

    public GameObject[] cameras;

    string inputKey;

    public CinemachineBrain[] follow;

    void Start()
    {

        for (int i = 0; i< cameras.Length; i++)
        {

            cameras[i].SetActive(false);

            follow[i].enabled = false;

        }

        cameras[0].SetActive(true);

        follow[0].enabled = true;
         
    }

    void Update()
    {

        for (int i = 0; i< 3; i++)
        {

            inputKey = i.ToString();

            if (Input.GetKeyDown(inputKey))
            {

                CameraSelector(i);

            }

        }

    }

    void CameraSelector(int a)
    {

        for (int i = 0; i < cameras.Length; i++)
        {

            cameras[i].SetActive(false);

            follow[i].enabled = false;

        }

        cameras[a].SetActive(true);

        Aiming.mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        follow[a].enabled = true;

    }

}
