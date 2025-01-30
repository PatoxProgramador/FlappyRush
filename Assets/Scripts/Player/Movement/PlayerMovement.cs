using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float velocity;// jumping up force/speed
     public float setVelocity;// jumping up force/speed
    [SerializeField] public float speed = 1f;// movement speed
    [SerializeField] public float multiplier = 1f;

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

        velocity = setVelocity;
        //makes player spawn in every scene without needing to copy prefabs
        DontDestroyOnLoad(this.gameObject);
        //counter scene is here
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    //Scene keeps track of the scene its on, to player can know where to spawn in each scene
    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        //player destroys itself
        if (scene.name == "TitleScreen")
        {

            SceneManager.sceneLoaded -= OnSceneLoaded;
            GameObject.Destroy(this.gameObject);

        }
        else
        {
            //finding spawn
            GameObject initialPositionGameObject = GameObject.FindGameObjectWithTag("PlayerSpawnPoint");
            //setting spawn location
            Transform initialPositionTransform = initialPositionGameObject.transform;
            //setting player position
            Vector3 playerInitialPosition = initialPositionTransform.position;
            this.transform.position = playerInitialPosition;

        }

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

        velocity = (setVelocity - 2) * multiplier;

        yield return new WaitForSeconds(0.05f);

        velocity = setVelocity * multiplier;

        yield return new WaitForSeconds(0.3f);

        body.linearVelocity = Vector2.up * 0;

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
