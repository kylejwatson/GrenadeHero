using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour {
	GameObject Grenade;
	[SerializeField]
	float throwStrength;
	[SerializeField]
	GameObject cam;
	float dir;
	int counter;
	// Use this for initialization
	void Start () {
		counter = 100;
		Grenade = Resources.Load ("Grenade") as GameObject;
		dir = 1f;
	}

	// Update is called once per frame
	void Update () {
		counter ++;
		float h = CrossPlatformInputManager.GetAxisRaw ("Horizontal");
		if (h != 0) {
			dir = h;
		}
			
		if (CrossPlatformInputManager.GetButtonDown ("Jump") && counter > 100) {
			counter = 0;
			GameObject newGrenade = Instantiate (Grenade);
			newGrenade.transform.position = this.transform.position + Vector3.right*dir;
			newGrenade.GetComponent<Rigidbody> ().velocity = this.GetComponent<Rigidbody> ().velocity;
			newGrenade.GetComponent<Rigidbody> ().AddForce (Vector3.right*dir*throwStrength);

		}else if (CrossPlatformInputManager.GetButton ("Fire2") && counter > 50) {
			counter = 0;
			GameObject newGrenade = Instantiate (Grenade);
			newGrenade.transform.position = this.transform.position + Vector3.right*dir;
			newGrenade.GetComponent<Rigidbody> ().velocity = this.GetComponent<Rigidbody> ().velocity;
			newGrenade.GetComponent<Rigidbody> ().AddForce (Vector3.right*dir*throwStrength/2);
		}
	}
}
