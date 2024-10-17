using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public GameObject player;
    private float zoom;
    private float ogZoom;
    private float zoomMultiplier = 4f;
    private float minZoom = 2f;
    public float maxZoom = 7f;
    private float velocity = 0f;
    private float smoothTime = 0.25f;
    public float zoomspeed = 1.1f;
    [SerializeField] private Camera cam;

    public static bool isZoom;
   
    void Start()
    {

        zoom = cam.orthographicSize;
        ogZoom = zoom;

        isZoom = false;

    }

    void Update()
    {

        if (isZoom)
        {

        zoom += zoomspeed * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);

        }
        else
        {

           zoom = ogZoom;
           zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
           cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);

        }

    }

}
