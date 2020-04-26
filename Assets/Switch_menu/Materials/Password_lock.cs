using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Password_lock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AN_Button.is_passsword_door == 1)
        {
            Cursor.visible = true;
            SceneManager.LoadScene(2);
        }
    }
}
