using UnityEngine;

public class RotateItself : MonoBehaviour
{
    [SerializeField] private Vector3 rotateVector;
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        transform.Rotate(rotateVector * rotateSpeed *  Time.deltaTime, Space.World);
    }
}
