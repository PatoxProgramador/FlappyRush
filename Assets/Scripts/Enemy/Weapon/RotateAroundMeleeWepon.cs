using UnityEngine;

public class RotateAroundObject : MonoBehaviour
{
    public GameObject targetObject;
    public float rotationSpeed = 20f;

    void Start()
    {
        targetObject = GameObject.Find("Rotating");
    }
    void Update()
    {
        if (targetObject != null)
        {
            // Rotate around the target object's position
            transform.RotateAround(targetObject.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
            
            // You can replace Vector3.up with any axis you need, like Vector3.forward or Vector3.right.
        }
        else
        {
            Debug.LogWarning("Target object not assigned!");
        }
    }
}
