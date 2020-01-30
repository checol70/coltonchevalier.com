using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<FixedJoint>().connectedBody = gameObject.transform.root.gameObject.GetComponent<Rigidbody>();
	}
}
