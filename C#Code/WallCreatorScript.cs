using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreatorScript : MonoBehaviour
{
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j<20; j++)
            {
                Instantiate(wall, new Vector3((j-10)*2 + i%2,i, 19.5f), Quaternion.Euler(Vector3.zero));
            }
            for(int k = 0; k<20; k++)
            {
                Instantiate(wall, new Vector3(19.5f, i, (k - 10) * 2 + (i+1) % 2), Quaternion.Euler(new Vector3(0, 90, 0)));
            }
            for (int j = 0; j < 20; j++)
            {
                Instantiate(wall, new Vector3((j - 10) * 2 + (i+1) % 2, i, -20.5f), Quaternion.Euler(Vector3.zero));
            }
            for (int k = 0; k < 20; k++)
            {
                Instantiate(wall, new Vector3(-20.5f, i, (k - 10) * 2 + i % 2), Quaternion.Euler(new Vector3(0, 90, 0)));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
