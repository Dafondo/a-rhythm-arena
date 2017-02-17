using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistScript : MonoBehaviour {

	private float dist = 0f;

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		Vector3 pos = this.gameObject.transform.position;
		pos.x += 0.2f;
		this.gameObject.transform.position = pos;
		dist += 0.2f;

	}
		
}
