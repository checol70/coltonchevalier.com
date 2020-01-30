using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
   public IEnumerator DestroyInSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
