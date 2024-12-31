using UnityEngine;

public class CanvasFollowCamera : MonoBehaviour
{
    public Transform cameraTransform;

    void Update()
    {
        transform.position = cameraTransform.position + cameraTransform.forward * 2.0f; // Giữ khoảng cách
        transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position);
    }
}
