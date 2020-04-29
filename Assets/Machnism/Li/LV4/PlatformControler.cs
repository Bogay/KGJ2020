using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlatformControler : MonoBehaviour
{
    public float moveTime = 2.5f;
    public bool standing = false;
    Rigidbody rid;
    bool moved = false;
    // Start is called before the first frame update
    void Start()
    {
        this.rid = GetComponent<Rigidbody>();
        this.rid.velocity = new Vector3(0f, 5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        Debug.Log(this.standing);
        if (other.tag == "Player" && this.standing == true)
        {
            if (this.moved == false)
            {
                Debug.Log("move");
                StartCoroutine(this.Move(other.gameObject));
                this.moved = true;
            }
        }
    }
    IEnumerator Move(GameObject player)
    {
        this.rid.isKinematic = false;
        player.transform.parent = transform;
        for (int i = 0; i < this.moveTime / Time.deltaTime; i++)
        {
            transform.position += new Vector3(0f, 6f, 0f) * Time.deltaTime;
            yield return null;
        }
        this.rid.velocity = Vector3.zero;
        this.rid.isKinematic = true;
        player.transform.parent = null;
    }
}
