using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutiveChefHealth : MonoBehaviour
{

    [SerializeField]private float health;
    public float maxHealth;

    [SerializeField] EnemyHealthBar healthBar;


    void Start()
    {
        //sets health to max
        health = maxHealth;
        
        healthBar = GetComponentInChildren<EnemyHealthBar>();
        //updates the current health in health bar
        healthBar.UpdateHealthBar(health, maxHealth);

    }

    void Update()
    {

        if (health == 0f)
        {

            Destroy(gameObject);

        }

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {

         if (other.tag == "PlayerBullet")
        {

            health -= 1f;
            //updates the damage in health bar
            healthBar.UpdateHealthBar(health,maxHealth);

        }

    }

}