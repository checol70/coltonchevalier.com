using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestVolleyballScript : NetworkBehaviour
{
    [SyncVar]
    public float interp;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<NetworkTransform>().interpolateMovement = interp;
        if (Input.GetKey("space"))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up *40, ForceMode.VelocityChange);
        }
    }
}
