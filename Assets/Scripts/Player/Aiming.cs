using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Aiming : MonoBehaviour
{

    private Camera mainCam;

    private Vector3 mousePos;

    private GameObject CrossHair;

    private Firing firing;

    [Range(0f, 20)]
    [SerializeField]
    private float aimSpeed = 10f;


    [Range(0f, 1f)]
    [SerializeField]
    private float spriteFlipCoolDown = 0.275f;
    private float spriteFlipCoolDownTimer = 0f;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        this.FindBulletSpawnPoint();
    }

    void FixedUpdate()
    {

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);// cursor location

        Vector3 rotation = mousePos - transform.position;

        float zRotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        PlayerMovement playerMovement = this.transform.parent.GetComponent<PlayerMovement>();
        if (spriteFlipCoolDownTimer <= 0)
        {
            spriteFlipCoolDownTimer = this.spriteFlipCoolDown;
            if (zRotation < 90 && zRotation > -90)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipY = false;
                this.transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite = playerMovement.faces[1];
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipY = true;
                this.transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite = playerMovement.faces[0];
            }
        }
        else
        {
            spriteFlipCoolDownTimer -= Time.fixedDeltaTime;
        }

        float recoilAndRecovery = this.firing.FireAndReturnRecoil();
        var newRoation = Quaternion.Euler(0, 0, zRotation + recoilAndRecovery);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRoation, Time.fixedDeltaTime * aimSpeed);
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
}
