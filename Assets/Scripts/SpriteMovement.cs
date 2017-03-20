using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovement : MonoBehaviour {

	public GameObject conductorObject;
	private MusicManager conductor;

	public float bounceHeight = 0.5f;

	private bool bouncing;
	private bool up;

	private float lastBeat;

	private Vector3 destination;

	// Use this for initialization
	void Start () {
		bouncing = false;
		up = false;
		conductor = conductorObject.GetComponent<MusicManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (bouncing) {
			if(up && transform.position == destination) {
				destination.y -= bounceHeight;
				up = false;
			}
			if (!up && transform.position == destination) {
				bouncing = false;
			}

			transform.position = Vector3.Lerp (transform.position, destination, 8*(conductor.songposition - lastBeat));
		}
	}

	public void bounce(float lastBeat) {
		bouncing = true;
		up = true;
		destination = transform.position;
		destination.y += bounceHeight;
		this.lastBeat = lastBeat;
	}
}
