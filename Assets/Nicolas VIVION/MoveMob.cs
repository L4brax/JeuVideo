using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMob : MonoBehaviour {

	public Vector3 currentSpeed;
	public float acceleration = 8f; // unit per second, per second
	public float maxSpeed = 4f; // unit per second

	public void mouve(float x, float y){
		transform.rotation = Quaternion.Euler(0,0,0);
	
		Vector3 currentAcceleration = new Vector3 (
				x * acceleration,
				y * acceleration,
				0
			);
	
		currentSpeed += currentAcceleration;
	
		currentSpeed = Vector3.ClampMagnitude (currentSpeed, maxSpeed);
		
		if (currentAcceleration.magnitude == 0) currentSpeed *= 0f;

		this.transform.position += currentSpeed * Time.deltaTime;
		
	}
}
