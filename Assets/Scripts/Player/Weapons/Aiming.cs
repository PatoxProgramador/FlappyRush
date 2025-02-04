using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;

public class Aiming : MonoBehaviour
{
    public static Camera mainCam;
    private Vector3 mousePos;
    private GameObject CrossHair;
    private Firing firing;
    GameObject parent;

    [Header("Gun position")]
    public float gunY;
    public float gunX;

    [Range(0f, 20)]
    [SerializeField]
    private float aimSpeed = 10f;

    private bool canAim = true; // New variable to control aiming

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        this.FindBulletSpawnPoint();

        //counter scene is here
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        CinemachineCamera a = FindAnyObjectByType<CinemachineCamera>();
        //parent = GameObject.FindGameObjectWithTag("Player");
        parent = transform.parent.gameObject;
        a.Target.TrackingTarget = parent.transform;

    }

    //Scene keeps track of the scene its on, to player can know where to spawn in each scene
    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        //player destroys itself
        if (scene.name == "TitleScreen")
        {

            SceneManager.sceneLoaded -= OnSceneLoaded;

        }
        else
        {
        
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

            this.FindBulletSpawnPoint();
            
            CinemachineCamera a = FindAnyObjectByType<CinemachineCamera>();
            a.Target.TrackingTarget = parent.transform;
           

        }

    }

    private void OnEnable() 
    {
        PlayerHealth.onPlayerDeath += DisableAiming; // Subscribe to death event
    }

    private void OnDisable() 
    {
        PlayerHealth.onPlayerDeath -= DisableAiming; // Unsubscribe from death event
    }

    void FixedUpdate()
    {
        if (!Pause.isPaused && canAim) // Check if aiming is allowed
        {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition); // Cursor location
            Vector3 rotation = mousePos - transform.position;

            float zRotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            PlayerMovement playerMovement = this.transform.parent.GetComponent<PlayerMovement>();
            if (zRotation < 90 && zRotation > -90)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                this.transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite = playerMovement.faces[1];
                this.transform.localPosition = new Vector3(gunX, gunY, 0f);
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipY = true;
                this.transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite = playerMovement.faces[0];
                this.transform.localPosition = new Vector3(-gunX, gunY, 0f);
            }

            float recoilAndRecovery = this.firing.FireAndReturnRecoil();
            var newRotation = Quaternion.Euler(0, 0, zRotation + recoilAndRecovery);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.fixedDeltaTime * aimSpeed);
        }
    }

    private void FindBulletSpawnPoint()
    {
        this.CrossHair = this.transform.Find("CrossHair").gameObject;
        if (!this.CrossHair)
        {
            Debug.LogError("Failed To Find BulletSpawnPoint");
            return;
        }
        this.firing = this.CrossHair.GetComponent<Firing>();
        if (!this.firing)
        {
            Debug.LogError("Failed to find Firing script on BulletSpawnPoint");
        }
    }

    // Method to disable aiming
    private void DisableAiming()
    {
        canAim = false; // Set aiming to false when the player dies
    }

}
