using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class ExitScript : MonoBehaviour
{
    public string page;
    [DllImport("__Internal")]
    private static extern void Exit(string page);


    public void OnTriggerEnter(Collider other)
    {
        Exit(page);
    }
}
