using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnPoint : MonoBehaviour {
    LineRenderer pointer;
    public float maxDistance = 60f;
    private void Start()
    {
        gameObject.transform.root.gameObject.GetComponent<TankControllerScript>().BullTran = gameObject.transform;
        pointer = gameObject.transform.GetChild(1).gameObject.GetComponent<LineRenderer>();
    }
    private void FixedUpdate()
    {
        Ray r = new Ray(gameObject.transform.position, gameObject.transform.forward);
        RaycastHit raycastHit;
        if(Physics.Raycast(r, out raycastHit,maxDistance)){
            pointer.SetPosition(1, new Vector3(0, 0, raycastHit.distance));
        }
        else
        {
            pointer.SetPosition(1, new Vector3(0,0,maxDistance));
        }
    }
}
