using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class VolleyBallScript : NetworkBehaviour {
    public static GameObject volleyBall;
    public float maxSpeed = 40;
    Rigidbody rb;
    [SyncVar]
    float t;
    // Update is called once per frame
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
   /* private void Start()
    {
        if(volleyBall == null)
        {
            volleyBall = gameObject;
        }
        if(gameObject != volleyBall)
        {
            Destroy(gameObject);
        }
    }*/
    void FixedUpdate () {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
	}
    private void Update()
    {
        gameObject.transform.localScale = Vector3.Lerp(Vector3.one / 2, new Vector3(16, 16, 16), t/2);
        if(isServer)
            t += Time.deltaTime;
    }
   /* private void OnDestroy()
    {
        if(volleyBall == gameObject)
            volleyBall = null;
    }*/
}
