using System;
using System.Collections;
using System.Collections.Generic;

using Unity.Collections;

using UnityEngine;

public class DoubleJump : MonoBehaviour
{
	//[SerializeField] private bool grounded;
	[SerializeField] private Rigidbody rb;
	[SerializeField] private int maxJumps = 2;
	//[SerializeField] private int moveSpeed;
	private int jumps;
	[SerializeField] private float jumpForce = 5f;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
	}
	/// <summary>
	/// applies a Jump force to GameObject. Limits # of possibe jumps at once to maxJumps variable.
	/// </summary>
	void Jump()
	{
		if(jumps > 0)
		{
			rb.AddForce(Vector3.up * jumpForce);
			//grounded = false;
			jumps = jumps - 1;
		}

		if(jumps == 0)
		{
			return;
		}
	}

	/// <summary>
	/// detects if player is touching the ground. if so, resets players maxJumps count.
	/// </summary>
	/// <param name="other">object of player</param>
	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag($"Ground"))
		{
			jumps = maxJumps;
			//grounded = true;
			//moveSpeed = 2;
		}
	}

	
}