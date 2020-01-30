using System.Runtime.InteropServices;
using System.Collections;
using UnityEngine;

public class APShotScript : MonoBehaviour
{
    bool hasExploded;
    // We need setters for this URL.  It will only trigger if it isn't null or empty.
    private string URL;
    //this tests for if we have started the countdown for opening the new window.
    private bool hasBeenStarted;
    // Use this for initialization
   
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(ClearOut());
        WallScript ws = collision.rigidbody.gameObject.GetComponent<WallScript>();
        if(ws != null)
        {
            StartCoroutine(ws.DestroyInSeconds(0f));
        }
    }

    private IEnumerator ClearOut()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        
    }
}
