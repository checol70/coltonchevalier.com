using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBodyScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            WallScript ws = collision.rigidbody.gameObject.GetComponent<WallScript>();
            if (ws != null)
            {
                StartCoroutine(ws.DestroyInSeconds(.5f));
            }
        }
    }
}
