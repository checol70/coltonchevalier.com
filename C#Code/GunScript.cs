using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.root.gameObject.GetComponent<TankControllerScript>().Gun = gameObject;
	}
}
