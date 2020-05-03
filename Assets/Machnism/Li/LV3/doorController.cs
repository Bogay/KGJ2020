using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    Rigidbody rid;
    bool first_time_open = true;
    bool open_sure = false;
    // Start is called before the first frame update
    void Start()
    {
        this.rid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*/if (GameManager.door1_1 == true)
        {
            if (this.hasTrigger == false)
            {
                StartCoroutine(this.opening());
                this.hasTrigger = true;
            }
        }*/
        if (lightController.illuimnate_it_1 && first_time_open && doorManager.door1_1 == true)
        {
            StartCoroutine(this.opening());
            first_time_open = false;
            open_sure = true;
        }
        else if (open_sure)
        {
            transform.Rotate(0, 0, -90);
            open_sure = false;
        }

        
    }
    IEnumerator opening()
    {
        transform.Rotate(0, 0, 90);
        yield return new WaitForSeconds(2.6f);
        this.rid.velocity = Vector3.zero;
    }
    
}
