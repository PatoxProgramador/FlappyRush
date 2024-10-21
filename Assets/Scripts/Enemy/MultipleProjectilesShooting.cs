using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleProjectilesShooting : MonoBehaviour
{
    public GameObject[] bullets; // Array of bullet prefabs
    public Transform bulletPos; // Position where bullets will spawn
    private float timer;

    public GameObject checkPointPos; // Checkpoint for distance comparison
    public GameObject playerPos; // Player's position

    public static bool isShooting; // Controls whether shooting is active

    void Start()
    {
        isShooting = true; // Temporarily set to true to test shooting
    }

    void Update()
    {
        // Temporarily skip distance check for testing
        timer += Time.deltaTime;

        if (timer > 1f)
        {
            timer = 0; // Reset the timer
            shoot();   // Call shoot method
        }
    }

    void shoot()
    {

        foreach (GameObject obj in bullets)
        {
            if (obj != null)
            {
                Debug.Log("Instantiating bullet: " + obj.name);
                Instantiate(obj, bulletPos.position, bulletPos.rotation); // Ensure the bullet spawns at bulletPos
            }
        }
    }
}

