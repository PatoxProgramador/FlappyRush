using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField]
    private float _speed = 10f;

    [Range(1, 100)]
    [SerializeField]
    private float _lifeTime = 3f;

    private Rigidbody2D _rigidbody;
    // add another string to the list if there is another tag the bullet need to avoid
    string[] tags = {"Player","AimCheck","MoveCheck","Portal","EnemyCheck","Zoom"};

    private void Start()
    {

        _rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _lifeTime);

    }

    private void FixedUpdate()
    {

        _rigidbody.velocity = transform.up * _speed;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        int count = 0;
        int replica = 0;

        for(int i = 0; i<tags.Length; i++)
        {
            
            //keeps track of each tag 'flag'
            count++;
            //check for specific tag
            if (other.tag != tags[i])
            { 
                //check if every tag are check out
                if (i < tags.Length-1 && replica == count-1)
                {
                    //does taht until it in the end of array
                    replica = count;
                    continue;

                }
                else if(i >= tags.Length-1 && replica == count-1)
                {
                    //finally does its job
                    Destroy(gameObject);

                }  

            }

        }

    }

}
