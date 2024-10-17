using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float velocity = 5f;// jumping up force/speed
    [SerializeField] private float speed = 1f;// movement speed

    public Sprite[] faces;

    private float horizontal;

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;

    [SerializeField] bool canMove;//locks movement

    private float jumpTimeCounter;
    public float jumpTime;

    void Start()
    {

        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (!Pause.isPaused)
        {

            //jump mechanic
            if (Input.GetKeyDown(KeyCode.Space))
            {

                jumpTimeCounter = jumpTime;
                body.velocity = Vector2.up * velocity;
                StartCoroutine(changeJumpBoost());

            }

            if (Input.GetKey(KeyCode.Space))
            {

                if (jumpTimeCounter > 0)
                {

                    body.velocity = Vector2.up * velocity;
                    StartCoroutine(changeJumpBoost());

                    jumpTimeCounter -= Time.deltaTime;

                }

            }
            //movement setup
            horizontal = Input.GetAxisRaw("Horizontal");

        }
       
    }

    private void FixedUpdate()
    {
        if (!Pause.isPaused)
        {

            if (canMove)
            {
                // movement action
                body.velocity = new Vector2(horizontal * speed, body.velocity.y);

            }

        }
        

    }

    
    //jump friction -- velocity changes value for a millisecond
    IEnumerator changeJumpBoost()
    {

        velocity = 3;

        yield return new WaitForSeconds(0.05f);

        velocity = 5;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //unlocks movement
        if (collision.gameObject.tag == "MoveCheck")
        {

            canMove = true;

        }

       

    }

}
