using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;

    [Header("BulletDamages")]
    public int damage;

    string[] tags = {"enemy","AimCheck","Zoom","EnemyCheck","EnemyBullet","PlayerBullet"};

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2 (direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        int count = 0;
        int replica = 0;

        for (int i = 0; i < tags.Length; i++)
        {

            //keeps track of each tag 'flag'
            count++;
            //check for specific tag
            if (other.tag != tags[i])
            {
                //check if every tag are check out
                if (i < tags.Length - 1 && replica == count - 1)
                {
                    //does taht until it in the end of array
                    replica = count;
                    continue;

                }
                else if (i >= tags.Length - 1 && replica == count - 1)
                {
                    //finally does its job
                    Destroy(gameObject);

                }

            }

        }

    }
}
