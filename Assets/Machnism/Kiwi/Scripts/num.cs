﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class num : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (check_password.a[0] == 6 && check_password.a[1] == 0 && check_password.a[2] == 6 && check_password.a[3] == 0)
        {
            Debug.Log("success");
            AN_Button.is_passsword_door = 2;
        
            Debug.Log("succ");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            SceneManager.LoadScene(1);
        }
    }
}