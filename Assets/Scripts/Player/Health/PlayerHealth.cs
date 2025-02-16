using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action onPlayerDeath;
    public float maxHealth;
    public static float currentHealth;
    [SerializeField]private float health;

    public static float radiusHealth;

    void Start()
    {

        currentHealth = maxHealth;
        //transform the current health in a angle of 90 degrees
        radiusHealth = (currentHealth / maxHealth) * -90;

    }

    void Update()
    {

        health = currentHealth;

        radiusHealth = (currentHealth / maxHealth) * -90;
        
    }

    public void TakeDamage(float amount)
    {

        if (currentHealth > 0)
        {

            currentHealth -= amount; //The amount multiplied by the health multiplier will allow us to control the armor

        }

        if (currentHealth <= 0)
        {
            onPlayerDeath?.Invoke();
        }
     
    }

}
