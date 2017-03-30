using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour {
	GameObject Grenade;
	[SerializeField]
	float throwStrength;
	[SerializeField]
	GameObject camera;
	int counter;
	// Use this for initialization
	void Start () {
		counter = 0;
		Grenade = Resources.Load ("Grenade") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		counter ++;
		if (CrossPlatformInputManager.GetButton ("Fire1") && counter > 100) {
			counter = 0;
			GameObject newGrenade = Instantiate (Grenade);
			newGrenade.transform.position = this.transform.position + camera.transform.forward;
			newGrenade.GetComponent<Rigidbody> ().AddForce (camera.transform.forward*throwStrength);
		}else if (CrossPlatformInputManager.GetButton ("Fire2") && counter > 100) {
			counter = 0;

			GameObject newGrenade = Instantiate (Grenade);
			newGrenade.transform.position = this.transform.position + camera.transform.forward;
			newGrenade.GetComponent<Rigidbody> ().velocity = this.GetComponent<Rigidbody> ().velocity;
			newGrenade.GetComponent<Rigidbody> ().AddForce (camera.transform.forward*throwStrength/2);
		}
	}
}
