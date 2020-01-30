using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShotType
{
    AP = 0,
    HE
}

public class TankControllerScript : MonoBehaviour
{
    Dictionary<ShotType, GameObject> originals = new Dictionary<ShotType, GameObject>();
    public float speed,
        tSpeed,
        turningSpeed;
    protected Transform
        camer;
    public GameObject
        Turret,
        Gun;
    public Rigidbody
        rightT,
        leftT;
    public Transform
        BullTran,
        serveTran;
    public Vector3 offset = new Vector3(0, 1.7f, -5);
    protected Rigidbody
        gun;

    public bool fired;

    protected void Start()
    {
        camer = Camera.main.transform;
        if (Gun != null)
        {
            gun = Gun.GetComponent<Rigidbody>();
        }
        else StartCoroutine(WaitForGun());
        originals.Add(ShotType.AP, (GameObject)Resources.Load("APShot"));
        originals.Add(ShotType.HE, (GameObject)Resources.Load("HEShot"));
        HEShotScript.explosion = (GameObject)Resources.Load("Explosion");
    }


    IEnumerator WaitForGun()
    {
        yield return new WaitWhile(() => Gun == null);
        gun = Gun.GetComponent<Rigidbody>();
    }


    protected void FixedUpdate()
    {
        camer.position = Gun.transform.position;
        camer.rotation = Gun.transform.rotation;
        camer.Translate(offset);
        if (Cursor.lockState == CursorLockMode.Locked || TouchHandlerScript.MyInput.touchControls)
        {
            float elev = -TouchHandlerScript.MyInput.GetAxis("Mouse Y") * speed / 2;
            float dir = TouchHandlerScript.MyInput.GetAxis("Mouse X") * speed;
            if (gun != null)
                gun.AddRelativeTorque(new Vector3(elev, dir, 0));
            if (!fired)
            {

                if (TouchHandlerScript.MyInput.GetAxis("Fire1") == 1)
                {
                    Shoot(BullTran.position, BullTran.rotation, ShotType.AP);
                    fired = true;
                }
                else if (TouchHandlerScript.MyInput.GetAxis("Fire2") == 1)
                {
                    Shoot(BullTran.position, BullTran.rotation, ShotType.HE);
                    fired = true;
                }
            }
            if (fired)
            {
                if (TouchHandlerScript.MyInput.GetAxis("Fire1") == 0 && TouchHandlerScript.MyInput.GetAxis("Fire2") == 0)
                {
                    fired = false;
                }
            }


            float turn = TouchHandlerScript.MyInput.GetAxis("Horizontal");
            float accel = TouchHandlerScript.MyInput.GetAxis("Vertical");

            Vector3 lMove = new Vector3(0, 0, accel * tSpeed + turn * turningSpeed);
            Vector3 rMove = new Vector3(0, 0, accel * tSpeed - turn * turningSpeed);

            leftT.AddRelativeForce(lMove);
            rightT.AddRelativeForce(rMove);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                LockMouseButtonScript.lockButton.transform.parent.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    void Shoot(Vector3 position, Quaternion rotation, ShotType type)
    {
        BullTran.GetChild(0).GetComponent<ParticleSystem>().Play();

        GameObject bull = Instantiate(originals[type], BullTran.position, BullTran.rotation) as GameObject;
        
        bull.GetComponent<Rigidbody>().AddForce(bull.transform.forward * 25, ForceMode.VelocityChange);
    }

}
