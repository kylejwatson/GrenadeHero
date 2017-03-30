using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class CharacterFeet : MonoBehaviour {

	[SerializeField]
	public bool grounded;
	// Use this for initialization
	void Start () {
		grounded = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButtonDown ("Fire2")) {
			grounded = !grounded;

		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag != "Player") {
			grounded = true;
		}
	}
	void OnTriggerExit(Collider col){
		if (col.tag != "Player") {
			grounded = false;
		}
	}
}
