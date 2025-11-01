using Unity.Mathematics;
using UnityEngine;

public class RotateCharachter : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up * 50 * Time.deltaTime);

    }
}
