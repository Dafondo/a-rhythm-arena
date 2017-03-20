using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistScript : MonoBehaviour {

	private Vector3 direction;

	// Use this for initialization
	void Start () {
		direction = transform.Find("Direction").right;
		//Debug.Log (direction);
		Destroy (this.gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		Vector3 pos = this.gameObject.transform.position;
		//pos.x += 0.2f;
		pos += Vector3.ClampMagnitude(direction, 0.2f);
		//Vector3 travel = direction.transform.forward;
		//pos.x += travel.x;
		//pos.y += travel.y;
		this.gameObject.transform.position = pos;
	}
		
}
