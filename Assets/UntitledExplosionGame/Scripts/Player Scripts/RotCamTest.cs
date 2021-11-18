using Mirror;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotCamTest : NetworkBehaviour
{
	public float minX = -60f;
	public float maxX = 60f;

	public float sensitivity;
	public Camera cam;
	//public CullingGroup playerCull;
	//public LayerMask playerMask = 1 << 6;

	float rotY = 0f;
	float rotX = 0f;

	public String maskString = "SelfPlayer";
	public LayerMask playerMask;
	public GameObject playerModel;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		if(isLocalPlayer)
		{
			playerModel.layer = LayerMask.NameToLayer("SelfPlayer");
		}
		
		//gameObject.layer = LayerMask.NameToLayer(maskString);
		//playerMask = ~playerMask;

	}

	private void Awake()
	{
		if(isLocalPlayer)
		{
			//playerModel.layer = LayerMask.NameToLayer("SelfPlayer");
		}
		//Debug.Log(playerMask);
		//cam.cullingMask = playerMask;
	}

	void Update()
	{
		if(isLocalPlayer)
		{
			cam.cullingMask &= ~(1 << LayerMask.NameToLayer("SelfPlayer"));
		}
		// 
		rotY += Input.GetAxis("Mouse X") * sensitivity;
		rotX += Input.GetAxis("Mouse Y") * sensitivity;

		rotX = Mathf.Clamp(rotX, minX, maxX);

		transform.localEulerAngles = new Vector3(0, rotY, 0);
		cam.transform.localEulerAngles = new Vector3(-rotX, 0, 0);

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//Mistake happened here vvvv
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		if (Cursor.visible && Input.GetMouseButtonDown(1))
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
	
	// Turn on the bit using an OR operation:
	// private void Show() {
	// 	cam.cullingMask |= 1 << LayerMask.NameToLayer("SomeLayer");
	// }
 //
	// // Turn off the bit using an AND operation with the complement of the shifted int:
	// private void Hide() {
	// 	cam.cullingMask &=  ~(1 << LayerMask.NameToLayer("SomeLayer"));
	// }
}
