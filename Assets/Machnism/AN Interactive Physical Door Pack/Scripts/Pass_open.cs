﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass_open : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AN_Button.is_passsword_door == 2)
        {
            Debug.Log("first time");
            transform.Rotate(0, 0, -60);
         
            AN_Button.is_passsword_door = 10;
        }
    }
}