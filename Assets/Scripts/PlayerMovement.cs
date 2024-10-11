using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float velocity = 3f;// jumping up force/speed
    [SerializeField] private float speed = 1f;// movement speed

    public Sprite[] faces;

    private float horizontal;
    private bool facingRight = true;

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;

    void Start()
    {

        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        //jump mechanic
        if (Input.GetKeyDown(KeyCode.Space))
        {

            body.velocity = Vector2.up * velocity;

        }
        //movement setup
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        // movement action
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);

    }
}
