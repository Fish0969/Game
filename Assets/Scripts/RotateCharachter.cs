using Unity.Mathematics;
using UnityEngine;

public class RotateCharachter : MonoBehaviour
{
    public int rotateSpeed;
    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

    }
}
