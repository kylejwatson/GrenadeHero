using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
	[SerializeField]
	public float explosionRate;
	[SerializeField]
	public float life;
	[SerializeField]
	public float bounce;

	private int counter;
	private int count;
	// Use this for initialization
	void Start () {
		counter = 0;
		count = 1;
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter > life) {
			Object.Destroy (this.gameObject);
		}
		if (counter > bounce) {
			count = -1;
		}
		if (this.transform.localScale.x > 0) {
			this.transform.localScale += Vector3.one * explosionRate * count;
		} else {
			this.GetComponentInChildren<MeshRenderer> ().enabled = false;
		}
	}
}
