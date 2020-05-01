using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stay_trigger : MonoBehaviour
{
    public GameObject plate;

    public float moveTime = 2.5f;
    public static bool standing = false;
    Rigidbody rid;
    bool moved = false;

    void Start()
    {

        rid = plate.GetComponent<Rigidbody>();
        rid.velocity = new Vector3(0f, 5f, 0f);
        rid.isKinematic = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && plate.transform.position.y<5.25)
        {

            rid.isKinematic = false;
            
            plate.transform.position += new Vector3(0f, 1f, 0f) * Time.deltaTime;
            //yield return new WaitForSeconds(0.2f);//0.1秒后继续执行for循环
            
            rid.velocity = Vector3.zero;
            rid.isKinematic = true;

        }

    }
}
