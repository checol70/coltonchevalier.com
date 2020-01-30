using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTrackScript : MonoBehaviour
{

    Material mat;
    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        gameObject.transform.root.gameObject.GetComponent<TankControllerScript>().rightT = gameObject.GetComponent<Rigidbody>();
        mat = gameObject.GetComponent<Renderer>().material;
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector2 offset = mat.mainTextureOffset;
        if (rb.velocity != Vector3.zero)
        {
            float y = offset.y;
            y += transform.InverseTransformDirection(rb.velocity).z * -Time.deltaTime;
            offset.y = y;
            mat.mainTextureOffset = offset;
        }
    }
}
