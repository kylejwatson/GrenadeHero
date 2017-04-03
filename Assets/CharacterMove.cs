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
	public float fakeDrag;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void LateUpdate () {
		float sprint = 1.0f;
		if (CrossPlatformInputManager.GetButton ("Sprint")) {
			sprint = sprintMultiply;
		}
		float totalSpeed = speed * sprint;
		float h = CrossPlatformInputManager.GetAxisRaw ("Horizontal");
		float v = CrossPlatformInputManager.GetAxisRaw ("Vertical");
		Vector3 vel = this.GetComponent<Rigidbody> ().velocity;
		if (vel.x > 0 && vel.x - fakeDrag >= 0) {
			this.GetComponent<Rigidbody> ().velocity = new Vector3 (vel.x - fakeDrag, vel.y, 0);
		}else if (vel.x < 0 && vel.x + fakeDrag <= 0) {
			this.GetComponent<Rigidbody> ().velocity = new Vector3 (vel.x + fakeDrag, vel.y, 0);
		}
		if (h > 0 && vel.x < totalSpeed) {
			this.GetComponent<Rigidbody> ().velocity = new Vector3 (vel.x + h * totalSpeed/10, vel.y, 0);
		}else if (h < 0 && vel.x > -totalSpeed) {
			this.GetComponent<Rigidbody> ().velocity = new Vector3 (vel.x + h * totalSpeed/10, vel.y, 0);
		}
		if (isGrounded () && v == 1) {
			this.GetComponent<Rigidbody> ().AddForce (Vector3.up * jumpSpeed);
		}
		Debug.Log ("Before : " + vel);
		Debug.Log ("After : " + this.GetComponent<Rigidbody> ().velocity);
	}

	bool isGrounded(){
		return feet.GetComponent<CharacterFeet> ().grounded;
	}
}
