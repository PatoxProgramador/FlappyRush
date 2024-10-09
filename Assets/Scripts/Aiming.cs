using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Aiming : MonoBehaviour
{

    private Camera mainCam;

    private Vector3 mousePos;

    void Start()
    {

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    void Update()
    {

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);// cursor location

        Vector3 rotation = mousePos - transform.position;

        float zRotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, zRotation);
        
    }

}
