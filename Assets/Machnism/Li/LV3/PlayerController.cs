using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public string vertical, horizontal;
    Rigidbody rid;
    NavMeshAgent agent;
    bool pressing = false;
    // Start is called before the first frame update
    void Start()
    {
        this.rid = GetComponent<Rigidbody>();
        this.agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(this.vertical) || Input.GetButton(this.horizontal))
        {
            this.pressing = true;
        }
        else
        {
            this.pressing = false;
        }
        if (this.pressing)
        {
            this.rid.velocity = new Vector3(Input.GetAxis(this.horizontal), 0f, Input.GetAxis(this.vertical)).normalized * 7f;
        }
    }
}
