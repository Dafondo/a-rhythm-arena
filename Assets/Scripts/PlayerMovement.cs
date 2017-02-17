using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private enum Direction {N, E, S, W};
    private Vector3[] vectorDir = { new Vector3(0, 1, 0), new Vector3(1, 0, 0), new Vector3(0, -1, 0), new Vector3(-1, 0, 0) };
    private Direction direction = Direction.N;
    private int[][] testmap1 = { new int[] { 0, 1, 0 }, new int[] { 0, 1, 0 }, new int[] { 0, 0, 0 } };
    private int currX = 0;
    private int currY = 0;
    private float timeElapsed = 0.0f;

    private float lastBeat;
    public float bpm;
    public float beat;
	public float halfBeat;
    public GameObject conductorObject;
    private MusicManager conductor;

	private Vector3 destination;
	private bool shouldMove;

	public float bounceHeight = 0.2f;

	private bool bouncing;
	private bool up;

	public GameObject projectile;
	private Transform sprite;
	private Animator animator;

	// Use this for initialization
	void Start () {
		destination = transform.position;
		shouldMove = false;
        conductor = conductorObject.GetComponent<MusicManager>();
        lastBeat = 0;
        bpm = conductor.bpm;
        beat = 60f / bpm;
		halfBeat = beat / 2f;

		sprite = transform.Find ("PlayerSprite");
		animator = sprite.GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () {
        readInput();
        //Debug.Log("Song pos: " + conductor.songposition);
        //Debug.Log("lastBeat: " + lastBeat);
        //Debug.Log("beat: " + beat);

        //if (conductor.songposition > lastBeat + beat)
        //{
            //move();
			//attack();
            //lastBeat += beat;
			//Debug.Log ("beat");
        //}

		if (conductor.songposition > lastBeat + halfBeat) {
			if (shouldMove) {
				move ();
			}
			if (!shouldMove) {
				attack ();
			}
			shouldMove = !shouldMove;
			lastBeat += halfBeat;
		}

		//Debug.Log ("Position: " + transform.position);
		//Debug.Log ("Destination: " + destination);

		if(up && transform.position == destination) {
			destination.y -= bounceHeight;
			up = false;
		}
		if (!up && transform.position == destination) {
			bouncing = false;
		}
		transform.position = Vector3.Lerp (transform.position, destination, 8*(conductor.songposition - lastBeat));
    }

    void FixedUpdate() {
        //if (conductor.songposition > lastBeat + beat)
        //{
        //    Debug.Log("move");
        //    move();
        //    lastBeat += beat;
        //}
        //    if (timeElapsed >= 0.5)
        //    {
        //        move();
        //        timeElapsed = 0;
        //    }
        //    else
        //    {
        //        timeElapsed += Time.fixedDeltaTime;
        //    }
    }

        void readInput() {
        if (Input.GetButtonDown("Up")) {
            direction = Direction.N;
        }
        else if (Input.GetButtonDown("Right")) {
            direction = Direction.E;
        }
        else if (Input.GetButtonDown("Down")) {
            direction = Direction.S;
        }
        else if (Input.GetButtonDown("Left")) {
            direction = Direction.W;
        }
        //Debug.Log(direction);
    }

    void move() {
		//Vector3 destination;
        //Debug.Log("New pos: " + currX + ", " + currY);
		if (direction == Direction.N && currY < 2 && testmap1 [currX] [currY + 1] == 0) {
			destination = transform.position + vectorDir [(int)direction];
			currY++;
		} else if (direction == Direction.E && currX < 2 && testmap1 [currX + 1] [currY] == 0) {
			destination = transform.position + vectorDir [(int)direction];
			currX++;
		} else if (direction == Direction.S && currY > 0 && testmap1 [currX] [currY - 1] == 0) {
			destination = transform.position + vectorDir [(int)direction];
			currY--;
		} else if (direction == Direction.W && currX > 0 && testmap1 [currX - 1] [currY] == 0) {
			destination = transform.position + vectorDir [(int)direction];
			currX--;
		} else {
			destination = transform.position;
		}
		//destination.y += bounceHeight;
		//sprite.GetComponent<SpriteMovement> ().bounce (lastBeat);
		//up = true;
    }

	void attack() {
		if (projectile != null) {
			//Debug.Log ("attack");
			animator.SetBool ("Fire", true);
			Instantiate (projectile, projectilePos(), Quaternion.identity);
		}
	}

	Vector3 projectilePos() {
		Vector3 result = this.gameObject.transform.Find("PlayerSprite").transform.position;
		result.x += 0.44f;
		result.y -= 0.12f;

		return result;
	}

	void attackEnd() {
		animator.SetBool ("Fire", false);
	}
}
