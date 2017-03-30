using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class CharacterMove : MonoBehaviour {
	[SerializeField]
	public float speed;
	[SerializeField]
	public float sprintMultiply;
	[SerializeField]
	public GameObject feet;
	[SerializeField]
	public float jumpSpeed;
	[SerializeField]
	public float lerpSpeed;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void LateUpdate () {
		Vector3 vel = this.GetComponent<Rigidbody> ().velocity;
		vel = new Vector3 (vel.x, 0, vel.z);
		float sprint = 1.0f;
		if (CrossPlatformInputManager.GetButton ("Sprint")) {
			sprint = sprintMultiply;
		}
        float totalSpeed = speed * sprint;
		float h = CrossPlatformInputManager.GetAxisRaw ("Horizontal") * totalSpeed;
		float v = CrossPlatformInputManager.GetAxisRaw ("Vertical") * totalSpeed;
		Vector3 desiredMovement = (this.transform.forward * v) + (this.transform.right * h);

		/*if (Mathf.Abs(desiredMovement.x) > Mathf.Abs(vel.x)) {
			vel.x = desiredMovement.x;
		}
		if (Mathf.Abs(desiredMovement.z) > Mathf.Abs(vel.z)) {
			vel.z = desiredMovement.z;
		}*/
		if (vel.sqrMagnitude < desiredMovement.sqrMagnitude) {
			vel = Vector3.Lerp (vel, desiredMovement, lerpSpeed);
		} else {
			//vel = desiredMovement - vel;
		}
		vel += Vector3.up * this.GetComponent<Rigidbody> ().velocity.y; 
		this.GetComponent<Rigidbody> ().velocity = vel;

		if (isGrounded () && CrossPlatformInputManager.GetButtonDown ("Jump")) {
			this.GetComponent<Rigidbody> ().AddForce (Vector3.up * jumpSpeed);
		}
	}

	bool isGrounded(){
		return feet.GetComponent<CharacterFeet> ().grounded;
	}
}
