using UnityEngine;

public class RotateAroundObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Transform rotateAround;
    void Update()
    {
        this.transform.RotateAround(rotateAround.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
