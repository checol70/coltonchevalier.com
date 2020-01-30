using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchButtonScript : MonoBehaviour
{
    public static GameObject lockButton;
    public GameObject touchInputs;
    // Use this for initialization
    void Start()
    {
        if (lockButton == null)
        {
            lockButton = gameObject;
        }
        else if (lockButton != gameObject)
        {
            Destroy(gameObject);
        }
        gameObject.GetComponent<Button>().onClick.AddListener(TouchActive);
    }

    void TouchActive()
    {
        for(int i = 0; i < touchInputs.transform.childCount; i++)
        {
            touchInputs.transform.GetChild(i).gameObject.SetActive(true);
        }
        TouchHandlerScript.MyInput.touchControls = true;
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
