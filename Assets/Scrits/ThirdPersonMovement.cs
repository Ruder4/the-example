using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Transform cameraTransform;
	CharacterController controller;

	public float mouseSensitivity = 100f;
	public float playerSpeed = 10f;
	float cameraRotation = 0f;

	private void Start()
	{
		controller = GetComponent<CharacterController>();
		Cursor.visible = false;
	}

	void CameraHandler()
	{
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		cameraRotation -= mouseY;
		cameraRotation = Mathf.Clamp(cameraRotation, -90f, 90f);

		cameraTransform.localRotation = Quaternion.Euler(cameraRotation, 0f, 0f);
		controller.transform.Rotate(Vector3.up * mouseX);
	}
	void MovementHandler()
	{
		float playerX = Input.GetAxis("Horizontal");
		float playerY = Input.GetAxis("Vertical");
		
		Vector3 move = controller.transform.right * playerX + controller.transform.forward * playerY;
		controller.Move(move * playerSpeed * Time.deltaTime);
	}

	private void Update()
	{
		CameraHandler();
		MovementHandler();
	}
}