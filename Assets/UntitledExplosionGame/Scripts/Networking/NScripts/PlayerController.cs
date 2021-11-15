using System;
using Mirror;

using NetworkGame.Networking;

using UnityEngine;
using UnityEngine.Animations;



namespace NetworkGame
{
	public class PlayerController : NetworkBehaviour
	{
		[SerializeField] private float speed = 4f;
		[SerializeField] private float sprint = 8f;
		[SerializeField] private Rigidbody rb;

		[Header("Animations")] [SerializeField] public Animator playerAnim;


		private void Start()
		{
			playerAnim = GetComponentInChildren<Animator>();
			//rb = GetComponent<Rigidbody>();
		}

		private void Awake()
		{
			// rb
		}

		// Update is called once per frame
		private void Update()
		{
			if(isLocalPlayer)
			{
				
				if(Input.GetKey(KeyCode.LeftShift))
				{
					Sprint();

				}
				else
				{
					Walk();
				}

				if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.F))
				{
					//&& !Input.GetKey(KeyCode.LeftShift
					playerAnim.Play("Running");
				}
				else if(Input.GetKey(KeyCode.F))
				{
					playerAnim.Play("Shooting");
				}
				else
				{
					playerAnim.Play("Idle");
				}
			}
		}

		private void Walk()
		{
			// rb.velocity += transform.right * Time.deltaTime * speed * Input.GetAxis("Horizontal");
			// rb.velocity += transform.forward * Time.deltaTime * speed * Input.GetAxis("Horizontal");
			 transform.position += transform.right * Time.deltaTime * speed * Input.GetAxis("Horizontal");
			 transform.position += transform.forward * Time.deltaTime * speed * Input.GetAxis("Vertical");
			//playerAnim.SetFloat("SprintSpeed", 1);
			
		}
		private void Sprint()
		{
			transform.position += transform.right * Time.deltaTime * sprint * Input.GetAxis("Horizontal");
			transform.position += transform.forward * Time.deltaTime * sprint * Input.GetAxis("Vertical");
			//playerAnim.SetFloat("SprintSpeed", 3);
			
			
		}
	}
}