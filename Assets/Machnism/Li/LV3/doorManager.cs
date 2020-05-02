using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorManager : MonoBehaviour
{
    public static bool door1_1 = false;
    public lightController button1_1, button1_2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (button1_1.standing == true && button1_2.standing == true)
        {
            door1_1 = true;
        }
    }
}
