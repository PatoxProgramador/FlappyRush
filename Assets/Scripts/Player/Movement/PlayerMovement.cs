using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float velocity = 5f;// jumping up force/speed
    [SerializeField] public float speed = 1f;// movement speed

    public Sprite[] faces;

    private float horizontal;

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;

    private float jumpTimeCounter;
    public float jumpTime;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        EnablePlayerMovement();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnEnable() {
        PlayerHealth.onPlayerDeath += DisablePlayerMovement;
    }

    private void OnDisable() {
        PlayerHealth.onPlayerDeath -= DisablePlayerMovement;
    }

    void Update()
    {

        if (!Pause.isPaused)
        {

                //jump mechanic
                if (Input.GetKeyDown(KeyCode.Space))
                {

                    jumpTimeCounter = jumpTime;
                    body.linearVelocity = Vector2.up * velocity;
                    StartCoroutine(changeJumpBoost());

                }
                if (Input.GetKey(KeyCode.Space))
                {

                    if (jumpTimeCounter > 0)
                    {

                        body.linearVelocity = Vector2.up * velocity;

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

                // movement action
                body.linearVelocity = new Vector2(horizontal * speed, body.linearVelocity.y);

        }

    }
    
    //jump friction -- velocity changes value for a millisecond
    IEnumerator changeJumpBoost()
    {

        velocity = 3;

        yield return new WaitForSeconds(0.05f);

        velocity = 5;

    }


    private void DisablePlayerMovement()
    {
        //animator.enable = false;
        body.bodyType = RigidbodyType2D.Static;
    }

    private void EnablePlayerMovement()
    {
        //animator.enable = true;
        body.bodyType = RigidbodyType2D.Dynamic;
    }
}
