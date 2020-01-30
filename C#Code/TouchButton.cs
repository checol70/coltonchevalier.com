using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void SetTouchOn()
    {
        TouchHandlerScript.MyInput.touchControls = true;
        int child = TouchHandlerScript.MyInput.gameObject.transform.childCount;
        for(int i =0; i< child; i++)
        {
            TouchHandlerScript.MyInput.gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
