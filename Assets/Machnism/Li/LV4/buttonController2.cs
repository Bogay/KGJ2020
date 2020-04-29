using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController2 : MonoBehaviour
{
    public GameObject playform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// OnTriggerStay is called once per frame for every Collider other
    /// that is touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.playform.GetComponent<PlatformControler>().standing = true;
        }
    }
}
