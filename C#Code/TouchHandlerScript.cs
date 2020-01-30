using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandlerScript : MonoBehaviour {
    // this script will let us access input from more than just the Input class, so that we can do touch screen controls without changing tank script too much.
    public static TouchHandlerScript MyInput;
    //this is to store the different Axes
    public Dictionary<string, float> Axes = new Dictionary<string, float>();
    public Joystick body, turret;
    //this is to test for if the touch controls are enabled.
    public bool touchControls;

    private void OnEnable()
    {
        if (MyInput == null)
        {
            MyInput = this;
        }
        else if (MyInput != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Axes.Add("Horizontal", 0f);
        Axes.Add("Vertical", 0f);
        Axes.Add("Fire1", 0f);
        Axes.Add("Fire2", 0f);
        Axes.Add("Mouse X", 0f);
        Axes.Add("Mouse Y", 0f);
    }
    public void Fire(string s)
    {
        Axes[s] = 1;
    }
    public void Detonate(string s)
    {
        Axes[s] = 0;
    }
    // Update is called once per frame
    void Update () {
        if (touchControls)
        {

            Axes["Horizontal"] = body.Horizontal;
            Axes["Vertical"] = body.Vertical;
            Axes["Mouse X"] = turret.Horizontal;
            Axes["Mouse Y"] = turret.Vertical;
        }
        else
        {
            Axes["Horizontal"] = Input.GetAxis("Horizontal");
            Axes["Vertical"] = Input.GetAxis("Vertical");
            Axes["Fire1"] = Input.GetAxis("Fire1");
            Axes["Fire2"] = Input.GetAxis("Fire2");
            Axes["Mouse X"] = Input.GetAxis("Mouse X");
            Axes["Mouse Y"] = Input.GetAxis("Mouse Y");
        }
	}
    public float GetAxis(string axis)
    {
        return Axes[axis];
    }
}
