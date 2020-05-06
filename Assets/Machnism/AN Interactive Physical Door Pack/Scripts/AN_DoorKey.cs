using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_DoorKey : MonoBehaviour
{
    [Tooltip("True - red key object, false - blue key")]
    public bool isRedKey = true;
    AN_HeroInteractive hero;

    // NearView()
    float distance;
    float angleView;
    Vector3 direction;

    GameObject father_gameObject;   //宣告一個GameObject(用來放取得的子物件)。
    //public Timer sha_hold;
    public GameObject fdoor;
    public static bool first_clone = false;

    private void Start()
    {
        hero = FindObjectOfType<AN_HeroInteractive>(); // key will get up and it will saved in "inventary"
        fdoor = GameObject.Find("the_door");
    }

    void Update()
    {
        if (NearView() && Input.GetKeyDown(KeyCode.E))
        {
            fdoor.GetComponent<AN_DoorScript>().Locked = false;
            if (isRedKey) hero.RedKey = true;
            else hero.BlueKey = true;
            gameObject.transform.parent = null;
            father_gameObject = GameObject.Find("unitychan");
            gameObject.transform.parent = father_gameObject.transform;
            Debug.Log(father_gameObject);
            
            first_clone = true;

        }
        if (father_gameObject != GameObject.Find("unitychan"))
        {
            fdoor.GetComponent<AN_DoorScript>().Locked = true;
        }
        /*if (first_clone)
        {
            Debug.Log(father_gameObject.transform);
            gameObject.transform.parent = father_gameObject.transform;
        }*/

    }

    bool NearView() // it is true if you near interactive object
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        direction = transform.position - Camera.main.transform.position;
        angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        if (distance < 2f) return true; // angleView < 35f && 
        else return false;
    }
    bool shadowNear()
    {
        GameObject[] shadow;
        shadow = GameObject.FindGameObjectsWithTag("shadow");
        float dis = 99999f;
        foreach (GameObject sha in shadow)
        {
            float d = Vector3.Distance(transform.position, sha.transform.position);
            if (d < dis)
            {
                dis = d;
            }
        }
        if (dis < 2f) return true;
        else return false;
    }
}
