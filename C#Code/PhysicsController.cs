using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : TankControllerScript {
    
    


    IEnumerator WaitForGun()
    {
        yield return new WaitWhile(() => Gun == null);
        gun = Gun.GetComponent<Rigidbody>();
    }


    new private void FixedUpdate()
    {
        //camer.position = Gun.transform.position;
        //camer.rotation = Gun.transform.rotation;
        //camer.Translate(offset);
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float elev = -Input.GetAxis("Mouse Y") * speed / 2;
            float dir = Input.GetAxis("Mouse X") * speed;
            if (gun != null)
                gun.AddRelativeTorque(new Vector3(elev, dir, 0));
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(BullTran.position, BullTran.rotation);
            }
            float turn = Input.GetAxis("Horizontal");
            float accel = Input.GetAxis("Vertical");

            Vector3 lMove = new Vector3(0, 0, accel * tSpeed + turn * turningSpeed);
            Vector3 rMove = new Vector3(0, 0, accel * tSpeed - turn * turningSpeed);

            leftT.AddRelativeForce(lMove);
            rightT.AddRelativeForce(rMove);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                LockMouseButtonScript.lockButton.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    void Shoot(Vector3 position, Quaternion rotation)
    {
        GameObject bull = Instantiate(Resources.Load("APShot"), position, rotation) as GameObject;

        bull.GetComponent<Rigidbody>().AddForce(bull.transform.forward * 50, ForceMode.VelocityChange);
    }
}
