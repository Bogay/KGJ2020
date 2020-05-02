using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stay_trigger_light : MonoBehaviour
{
    public GameObject light_1;

    
    public static bool standing = false;
    Rigidbody rid;


    void Start()
    {

        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "shadow")
        {
            light_1.GetComponent<lightController>().standing = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        light_1.GetComponent<lightController>().standing = false;
    }
}


