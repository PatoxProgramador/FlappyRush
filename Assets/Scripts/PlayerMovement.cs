using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float velocity = 3f;// jumping up mechanics
    [SerializeField] private float speed = 1f;// movement speed

    private float horizontal;
    private bool facingRight = true;
    
    private Rigidbody2D body;

    void Start()
    {

        body = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            body.velocity = Vector2.up * velocity;

        }

        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();
        
    }

    private void FixedUpdate()
    {
        
        body.velocity = new Vector2 (horizontal * speed, body.velocity.y);

    }

    private void Flip()
    {

        if (facingRight && horizontal < 0 || !facingRight && horizontal > 0f)
        {
            
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }

    }

}
