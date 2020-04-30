using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate_easy : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool stand = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stand == true && transform.position.y<=5.285)
        {
            
            transform.position += new Vector3(0f, 6f, 0f);
            stand = false;
        }

    }
}
