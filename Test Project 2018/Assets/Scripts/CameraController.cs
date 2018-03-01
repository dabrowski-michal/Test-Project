using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] Transform playerTransform;
    [SerializeField] float rotationSpeed = 5.0f;
    [SerializeField] bool shouldOrbitAroundPlayer = true;

    [Range(0.01f, 1.0f)]
    public float smoothAmount = 0.5f;
    private Vector3 cameraOffset;

    void Start () {
        cameraOffset = transform.position - playerTransform.position;
	}
	
    //moving camera in Late Update
	private void LateUpdate () {
        Vector3 newPosition = playerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothAmount);

        //orbiting can be disabled in the inspector
        if (shouldOrbitAroundPlayer)
        {
            transform.LookAt(playerTransform);
            Quaternion cameraTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            cameraOffset = cameraTurnAngle * cameraOffset;
        }
	}
}
