using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnd : MonoBehaviour {

	void attackEnd() {
		GetComponent<Animator> ().SetBool ("Fire", false);
	}
}
