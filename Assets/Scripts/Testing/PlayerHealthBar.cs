using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{

    [SerializeField] float lifeAngle;

    void Start()
    {

        lifeAngle = PlayerHealth.radiusHealth;
        
    }

    void Update()
    {

        lifeAngle = PlayerHealth.radiusHealth;

        transform.localEulerAngles = new Vector3(0, 0, lifeAngle);
        
    }

}
