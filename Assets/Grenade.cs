using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Grenade : MonoBehaviour {

	[SerializeField]
	AudioClip impact;
	[SerializeField]
	float radius;
	GameObject explosion;
	[SerializeField]
	public float life;
	[SerializeField]
	public float force;
	private AudioSource sound;
	private int counter;
	// Use this for initialization
	void Start () {
		sound = this.GetComponent<AudioSource> ();
		counter = 0;
		explosion = Resources.Load ("Explosion") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter > life) {
			Collider[] colliders = Physics.OverlapSphere (this.transform.position,radius);
			foreach (Collider hit in colliders) {
				Rigidbody rb = hit.GetComponent<Rigidbody> ();
				if (rb != null) {
					rb.AddExplosionForce (force, this.transform.position, radius);
					//Debug.Log (rb.tag);
				}
			}
			GameObject newExplosion = Instantiate (explosion);
			newExplosion.transform.position = this.transform.position;
			Object.Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter (Collision col){
		sound.PlayOneShot (impact);
	}
}
