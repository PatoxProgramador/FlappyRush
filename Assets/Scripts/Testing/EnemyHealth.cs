using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField]private float health;
    public float maxHealth;

    [SerializeField] EnemyHealthBar healthBar;


    void Start()
    {

        health = maxHealth;
        
        healthBar = GetComponentInChildren<EnemyHealthBar>();
        healthBar.UpdateHealthBar(health, maxHealth);

    }

    // Update is called once per frame
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
            healthBar.UpdateHealthBar(health,maxHealth);

        }

    }

}
