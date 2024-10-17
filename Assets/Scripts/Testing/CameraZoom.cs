using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public GameObject player;
    private float zoom;
    private float zoomMultiplier = 4f;
    private float minZoom = 2f;
    public float maxZoom = 7f;
    private float velocity = 0f;
    private float smoothTime = 0.25f;
    public float zoomspeed = 1.1f;
    [SerializeField] private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        zoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 10.56f)
        {
        zoom += zoomspeed * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
        }
    }
}
