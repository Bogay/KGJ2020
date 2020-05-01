using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passwprd_bye : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (check_password.a[0] == 6 && check_password.a[1] == 0 && check_password.a[2] == 6 && check_password.a[3] == 0 )
        {
            Destroy(gameObject);
        }
    }
}
