using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

	public GameObject groundTile;
    public GameObject wallTile;
    private int[][] blankMap = { new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } };
	private int[][] testMap1 = { 
		new int[] { 0, 0, 0, 0, 0 }, 
		new int[] { 0, 0, 1, 0, 0 }, 
		new int[] { 0, 1, 1, 1, 0 }, 
		new int[] { 0, 0, 1, 0, 0 }, 
		new int[] { 0, 0, 0, 0, 0 } 
	};

    // Use this for initialization
    void Start () {
		createGrid (testMap1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void createGrid(int[][] map) {
		for (int i = 0; i < map.Length; i++) {
			for (int j = 0; j < map[i].Length; j++) {
                //Debug.Log(i + ", " + j);
                if (map [i][j] == 0) {
					Instantiate (groundTile, new Vector3 (i, j, 0), Quaternion.identity);
                    //Debug.Log("Instantiate: " + i + ", " + j);
				}
                else if(map[i][j] == 1)
                {
                    Instantiate(wallTile, new Vector3(i, j, 0), Quaternion.identity);
                }
			}
		}
	}
}
