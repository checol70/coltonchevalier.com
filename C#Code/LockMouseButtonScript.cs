using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LockMouseButtonScript : MonoBehaviour {
    public static GameObject lockButton;
	// Use this for initialization
	void Start () {
        if(lockButton == null)
        {
            lockButton = gameObject;
        }else if(lockButton != gameObject)
        {
            Destroy(gameObject);
        }
        gameObject.GetComponent<Button>().onClick.AddListener(StartMouseUp);
	}
    void StartMouseUp()
    {
        StartCoroutine(WaitForMouseUp());
    }
	IEnumerator WaitForMouseUp()
    {
        while (true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gameObject.transform.parent.gameObject.SetActive(false);
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }
    private void LateUpdate()
    {
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            gameObject.SetActive(false);
        }
    }
}
