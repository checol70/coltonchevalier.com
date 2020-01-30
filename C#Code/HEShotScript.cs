using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEShotScript : MonoBehaviour
{
    public static GameObject explosion;

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    private void Explode()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        Instantiate(Resources.Load("Explosion"), gameObject.transform.position, gameObject.transform.rotation);
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 10);
        foreach (Collider hit in hitColliders)
        {
            Rigidbody target = hit.gameObject.GetComponent<Rigidbody>();
            if (target != null)
            {
                target.AddExplosionForce(200, gameObject.transform.position, 100);
                Vector3 rand = new Vector3((Random.value * 300) + 60, Random.value * 90, Random.value * 300);
                target.AddTorque(rand, ForceMode.VelocityChange);
            }
        }
            Destroy(gameObject);
    }
}
