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
		/*Vector3 vel = this.GetComponent<Rigidbody> ().velocity;
		vel = new Vector3 (vel.x, 0, vel.z);
		float sprint = 1.0f;
		if (CrossPlatformInputManager.GetButton ("Sprint")) {
			sprint = sprintMultiply;
		}
        float totalSpeed = speed * sprint;
		float h = CrossPlatformInputManager.GetAxisRaw ("Horizontal") * totalSpeed;
		float v = CrossPlatformInputManager.GetAxisRaw ("Vertical") * totalSpeed;
		Vector3 desiredMovement = (this.transform.forward * v) + (this.transform.right * h);

		if (vel.sqrMagnitude < desiredMovement.sqrMagnitude && h+v != 0) {
			vel = Vector3.Lerp (vel, desiredMovement, lerpSpeed);
		} else {
			//vel = desiredMovement - vel;
		}
		vel += Vector3.up * this.GetComponent<Rigidbody> ().velocity.y; 
		this.GetComponent<Rigidbody> ().velocity = vel;
	*/
		float sprint = 1.0f;
		if (CrossPlatformInputManager.GetButton ("Sprint")) {
			sprint = sprintMultiply;
		}
		float totalSpeed = speed * sprint;
		float h = CrossPlatformInputManager.GetAxisRaw ("Horizontal");
		float v = CrossPlatformInputManager.GetAxisRaw ("Vertical");
		Vector3 curVel = this.GetComponent<Rigidbody> ().velocity;
		Vector3 desiredMovement = (this.transform.forward * v) + (this.transform.right * h);
		if (curVel.x < totalSpeed && curVel.x > -totalSpeed) {
			this.GetComponent<Rigidbody> ().velocity = new Vector3 (curVel.x + desiredMovement.x, curVel.y, curVel.z);
		}
		curVel = this.GetComponent<Rigidbody> ().velocity;
		if (curVel.z < totalSpeed && curVel.z > -totalSpeed) {
			this.GetComponent<Rigidbody> ().velocity = new Vector3 (curVel.x, curVel.y, desiredMovement.z + curVel.z);
		}
		//fix not actually doing term vel but doing it for each bit, learn vectors or something
		//if (this.GetComponent<Rigidbody> ().velocity.sqrMagnitude < totalSpeed) {
		//	this.GetComponent<Rigidbody> ().velocity += (v * this.transform.forward + h * this.transform.right);
		//}

		if (isGrounded () && CrossPlatformInputManager.GetButtonDown ("Jump")) {
			this.GetComponent<Rigidbody> ().AddForce (Vector3.up * jumpSpeed);
		}

	}

	bool isGrounded(){
		return true;//feet.GetComponent<CharacterFeet> ().grounded;
	}
}
