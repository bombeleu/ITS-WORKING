﻿using UnityEngine;
using System.Collections;
[RequireComponent (typeof(CharacterController))]
public class Movement : MonoBehaviour {
	public float rotateSpeed = 250;
	public float moveSpeed = 5;
	public float strafeSpeed = 2.5f;
	public float runMultiplier = 2;

	private Transform _myTransform;
	private CharacterController _controller;

	public void Awake(){
		_myTransform = transform;
		_controller = GetComponent<CharacterController> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!_controller.isGrounded) {
			_controller.Move(Vector3.down * Time.deltaTime);
		}
		Turn ();
		Walk ();
		Strafe ();

	}

	private void Turn(){
		if (Mathf.Abs (Input.GetAxis ("Rotate Player")) > 0) {
			//					Debug.Log ("ROTATE:" + Input.GetAxis ("Rotate Player"));
			_myTransform.Rotate(0, Input.GetAxis("Rotate Player")*Time.deltaTime*rotateSpeed, 0);
		}

	}
	private void Walk(){
		
		if (Mathf.Abs (Input.GetAxis ("Move Forward")) > 0) {
						//					Debug.Log ("ROTATE:" + Input.GetAxis ("Rotate Player"));
			if (Input.GetButton("Run")){
				_controller.SimpleMove (_myTransform.TransformDirection (Vector3.forward * Input.GetAxis ("Move Forward") * moveSpeed*runMultiplier));
			}
			// animation.CrossFade("Walkwalk"); <==if only we had a walking animation

						_controller.SimpleMove (_myTransform.TransformDirection (Vector3.forward * Input.GetAxis ("Move Forward") * moveSpeed));
		} 
		else {
			//animation.CrossFade("Idle"); <== if only we had an idle animation
				}
		}

	private void Strafe(){
		if (Mathf.Abs (Input.GetAxis ("Strafe")) > 0) {
						//					Debug.Log ("ROTATE:" + Input.GetAxis ("Rotate Player"));
						//animation.CrossFade("Strafe"); <= tfw no strafe animation
						_controller.SimpleMove (_myTransform.TransformDirection (Vector3.right * Input.GetAxis ("Strafe") * strafeSpeed));
				}
			else
		{			//animation.CrossFade("Idle"); <== if only we had an idle animation
		}
	}



}
