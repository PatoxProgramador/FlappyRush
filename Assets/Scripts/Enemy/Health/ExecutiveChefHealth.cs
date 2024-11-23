using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutiveChefHealth : MonoBehaviour
{
    public GameObject[] week = new GameObject[3];
    public GameObject[] medium = new GameObject[2];
    public GameObject hard;
    public GameObject spawnPoint;
    [SerializeField]private float health;
    public float maxHealth;

    [SerializeField] EnemyHealthBar healthBar;


    void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("spawnPoint");
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

            var randomChance = Random.Range(0, 100);
            if (randomChance == 0)
                {
                    foreach (GameObject obj in week)
                        {
                            Instantiate(obj, spawnPoint.transform.position, spawnPoint.transform.rotation);
                        }

                    foreach (GameObject obj in medium)
                        {
                            Instantiate(obj, spawnPoint.transform.position, spawnPoint.transform.rotation);
                        }

                            Instantiate(hard, spawnPoint.transform.position, spawnPoint.transform.rotation);
                }
            else
            {    var randomChef = Random.Range(0,3);
            
                if (randomChef == 0)
                    {
                        foreach (GameObject obj in week)
                        {
                            Instantiate(obj, spawnPoint.transform.position, spawnPoint.transform.rotation);
                        }
                    }
                if (randomChef == 1)
                    {
                        foreach (GameObject obj in medium)
                        {
                            Instantiate(obj, spawnPoint.transform.position, spawnPoint.transform.rotation);
                        }
                    }
                if (randomChef == 2)
                    {
                        Instantiate (hard, spawnPoint.transform.position, spawnPoint.transform.rotation); 
                    }
            }
            
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