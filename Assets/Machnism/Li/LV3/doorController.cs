using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    Rigidbody rid;
    bool hasTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        this.rid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.door1_1 == true)
        {
            if (this.hasTrigger == false)
            {
                StartCoroutine(this.opening());
                this.hasTrigger = true;
            }
        }
    }
    IEnumerator opening()
    {
        this.rid.velocity = new Vector3(-2f, 0f, 0f);
        yield return new WaitForSeconds(2.6f);
        this.rid.velocity = Vector3.zero;
    }
}
