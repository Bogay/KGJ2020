using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlatformControler : MonoBehaviour
{
    public float moveTime = 2.5f;
    public static bool standing = false;
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
        if (standing == true)
        {
            if (this.moved == false)
            {
                Debug.Log("move");
                StartCoroutine(Move(gameObject));
                this.moved = true;
            }
            standing = false;
        }

    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    /*void OnTriggerStay(Collider other)
    {
        Debug.Log("other.tag");
        Debug.Log("standing");
        if (standing == true)
        {
            if (this.moved == false)
            {
                Debug.Log("move");
                StartCoroutine(Move(other.gameObject));
                this.moved = true;
            }
        }

    }*/
    void start_move()
    {
        
    }
    IEnumerator Move(GameObject player)
    {
        this.rid.isKinematic = false;
        for (int i = 0; i < this.moveTime / Time.deltaTime; i++)
        {
            transform.position += new Vector3(0f, 6f, 0f) * Time.deltaTime;
            yield return null;
            if (!standing && !buttonController2.still)
                break;
            yield return new WaitForSeconds(0.2f);//0.1秒后继续执行for循环
        }
        this.rid.velocity = Vector3.zero;
        this.rid.isKinematic = true;

    }
}
