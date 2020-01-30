using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FireButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool fired;
    public string type;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!fired)
        {
            TouchHandlerScript.MyInput.Fire(type);
            fired = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TouchHandlerScript.MyInput.Detonate(type);
        fired = false;
    }
}
