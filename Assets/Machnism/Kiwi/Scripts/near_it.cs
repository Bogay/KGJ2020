using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class near_it : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneSwitcher()
    {
        Debug.Log("suc");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ;
    }
    
}
