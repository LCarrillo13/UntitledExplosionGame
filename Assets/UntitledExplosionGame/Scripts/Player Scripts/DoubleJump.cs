using System;
using System.Collections;
using System.Collections.Generic;

using Unity.Collections;

using UnityEngine;

public class DoubleJump : MonoBehaviour
{
	[SerializeField] private bool grounded;
	[SerializeField] private Rigidbody rb;
	[SerializeField] private int maxJumps = 2;
	[SerializeField] private int moveSpeed;
	private int jumps;
	[SerializeField] private float jumpForce = 5f;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
		{
			Jump();
		}
	}

	void Jump()
	{
		if(jumps > 0)
		{
			rb.AddForce(Vector3.up * jumpForce);
			grounded = false;
			jumps = jumps - 1;
		}

		if(jumps == 0)
		{
			return;
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag($"Ground"))
		{
			jumps = maxJumps;
			grounded = true;
			moveSpeed = 2;
		}
	}

	
}