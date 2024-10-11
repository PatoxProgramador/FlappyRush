using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class JumpTest : MonoBehaviour
{

    [SerializeField]float speed;
    float speed2 = 3f;
    float startSpeed;

    private float horizontal;

    private Rigidbody2D body;

    [SerializeField]bool canMove;

    public GameObject aim;
    [SerializeField] bool canAim;

    void Start()
    {

        aim.SetActive(false);

        body = GetComponent<Rigidbody2D>();

        startSpeed = speed;

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

                StartCoroutine(change());

        }

        if(canMove == true)
        {

            horizontal = Input.GetAxisRaw("Horizontal");
            body.velocity = new Vector2(horizontal * speed2, body.velocity.y);

        }

        if (canAim == true)
        {

            aim.SetActive(true);

        }
        
    }

    IEnumerator change()
    {

        speed -= 0.4f;
        body.velocity = Vector2.up * speed;

        yield return new WaitForSeconds(0.05f);

        if (speed > 0)
        {

            StartCoroutine(change());

        }
        else
        {

            StopCoroutine(change());
            speed = startSpeed;

        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "MoveCheck")
        {

            canMove = true;

        }

        if (collision.gameObject.tag == "AimCheck")
        {

            canAim = true;

        }

    }

}
