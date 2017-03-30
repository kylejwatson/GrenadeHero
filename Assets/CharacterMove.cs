using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class CharacterMove : MonoBehaviour {
	[SerializeField]
	public float speed;
	[SerializeField]
	public float sprintMultiply;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		float sprint = 1.0f;
		if (CrossPlatformInputManager.GetButton ("Sprint")) {
			sprint = sprintMultiply;
		}
        float totalSpeed = speed * sprint;
		float h = CrossPlatformInputManager.GetAxis ("Horizontal") * totalSpeed;
		float v = CrossPlatformInputManager.GetAxis ("Vertical") * totalSpeed;
		if (h + v != 0) {
			Vector3 vel = this.GetComponent<Rigidbody> ().velocity;
            if (vel.x > totalSpeed)
            {
                h = vel.x;
            }
            if (vel.z > totalSpeed)
            {
                v = vel.z;
            }
            vel = new Vector3 (0, vel.y, 0) + (this.transform.forward * v) + (this.transform.right * h);
            
			this.GetComponent<Rigidbody> ().velocity = vel;
		}
		//this.GetComponent<Rigidbody> ().velocity.Scale (Vector3.one * 0.005f);
		//this.GetComponent<CharacterController> ().Move (this.GetComponent<Rigidbody> ().velocity);

	}
}
