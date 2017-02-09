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
    public GameObject conductorObject;
    private MusicManager conductor;

	// Use this for initialization
	void Start () {
        conductor = conductorObject.GetComponent<MusicManager>();
        lastBeat = 0;
        bpm = conductor.bpm;
        beat = 60 / bpm;
    }
	
	// Update is called once per frame
	void Update () {
        readInput();
        //Debug.Log("Song pos: " + conductor.songposition);
        //Debug.Log("lastBeat: " + lastBeat);
        //Debug.Log("beat: " + beat);
        if (conductor.songposition > lastBeat + beat)
        {
            move();
            lastBeat += beat;
        }
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
        //Debug.Log("New pos: " + currX + ", " + currY);
        if (direction == Direction.N && currY < 2 && testmap1[currX][currY + 1] == 0) {
            transform.Translate(vectorDir[(int)direction]);
            currY++;
        }
        else if (direction == Direction.E && currX < 2 && testmap1[currX + 1][currY] == 0) {
            transform.Translate(vectorDir[(int)direction]);
            currX++;
        }
        else if (direction == Direction.S && currY > 0 && testmap1[currX][currY - 1] == 0) {
            transform.Translate(vectorDir[(int)direction]);
            currY--;
        }
        else if (direction == Direction.W && currX > 0 && testmap1[currX - 1][currY] == 0) {
            transform.Translate(vectorDir[(int)direction]);
            currX--;
        }
    }
}
