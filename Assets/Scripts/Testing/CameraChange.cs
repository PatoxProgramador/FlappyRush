using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraChange : MonoBehaviour
{

    public GameObject[] cameras;
    //[SerializeField]Transform []camTransform;

    string inputKey;

    public CinemachineBrain[] follow;

    void Start()
    {

        //camTransform = new Transform[cameras.Length];

        for (int i = 0; i< cameras.Length; i++)
        {

            cameras[i].SetActive(false);

            follow[i].enabled = false;

            //camTransform[i] = cameras[i].transform;

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

        //cameras[a].transform.position = camTransform[a].position;

        follow[a].enabled = true;

    }

}
