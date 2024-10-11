using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class JumpTest : MonoBehaviour
{

    [SerializeField]float speed = 10;

    private Rigidbody2D body;

    void Start()
    {

        body = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

                StartCoroutine(change());

        }
        
    }

    IEnumerator change()
    {

        speed -= 0.7f;
        body.velocity = Vector2.up * speed;

        yield return new WaitForSeconds(0.05f);

        if (speed > 0)
        {

            StartCoroutine(change());

        }
        else
        {

            StopCoroutine(change());
            speed = 10;

        }
        

    }

}
