using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;

    public static float radiusHealth;

    void Start()
    {

        currentHealth = maxHealth;
        radiusHealth = (currentHealth / maxHealth) * -90;

    }

    void Update()
    {

        radiusHealth = (currentHealth / maxHealth) * -90;
        
    }

    public void TakeDamage(float amount)
    {

        if (currentHealth > 0)
        {

            currentHealth -= amount;

        }

    }

}
