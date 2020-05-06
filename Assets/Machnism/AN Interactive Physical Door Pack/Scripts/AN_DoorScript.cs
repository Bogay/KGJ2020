using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AN_DoorScript : MonoBehaviour
{
    [Tooltip("If it is false door can't be used")]
    public bool Locked = false;
    [Tooltip("It is true for remote control only")]
    public bool Remote = false;
    [Space]
    [Tooltip("Door can be opened")]
    public bool CanOpen = true;
    [Tooltip("Door can be closed")]
    public bool CanClose = true;
    [Space]
    [Tooltip("Door locked by red key (use key script to declarate any object as key)")]
    public bool RedLocked = false;
    public bool BlueLocked = false;
    [Tooltip("It is used for key script working")]
    AN_HeroInteractive HeroInteractive;
    [Space]
    public bool isOpened = false;
    [Range(0f, 4f)]
    [Tooltip("Speed for door opening, degrees per sec")]
    public float OpenSpeed = 3f;
    public bool final = false;

    // NearView()
    float distance;
    float angleView;
    Vector3 direction;

    // Hinge
    [HideInInspector]
    public Rigidbody rbDoor;
    HingeJoint hinge;
    JointLimits hingeLim;
    float currentLim;

    //開門的聲音的啦
    AudioSource audioSource;

    void Start()
    {
        rbDoor = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();
        HeroInteractive = FindObjectOfType<AN_HeroInteractive>();
        this.audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!Remote && (NearView() && Input.GetKeyDown(KeyCode.E) || shadowNear())&&!final)
            Action();
        else if(!Remote && (NearView() && Input.GetKeyDown(KeyCode.E) ) && final)
            Action();

    }

    public void Action() // void to open/close door
    {
        if (!Locked)
        {
            
            // key lock checking
            if (HeroInteractive != null && RedLocked && HeroInteractive.RedKey)
            {
                Debug.Log("open1");
                RedLocked = false;
                HeroInteractive.RedKey = false;
            }
            else if (HeroInteractive != null && BlueLocked && HeroInteractive.BlueKey)
            {
                Debug.Log("open2");
                BlueLocked = false;
                HeroInteractive.BlueKey = false;
            }
            
            // opening/closing
            if (isOpened && CanClose & !RedLocked && !BlueLocked)
            {
                isOpened = false;
                

            }
            else if(!isOpened && CanOpen & !RedLocked && !BlueLocked)
            {
                isOpened = true;
                //FindObjectOfType<AudioManager>().Play("中門");
                Debug.Log("open3");
                transform.Rotate(0, 0, 60);

                //rbDoor.AddRelativeTorque(new Vector3(0, 0, 100f)); 
            }
        
        }
    }

    bool NearView() // it is true if you near interactive object
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        direction = transform.position - Camera.main.transform.position;
        angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        if (distance < 3f) return true; // angleView < 35f && 
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

    private void FixedUpdate() // door is physical object
    {
        if (isOpened)
        {
            currentLim = 85f;
        }
        else
        {
            
            // currentLim = hinge.angle; // door will closed from current opened angle
            if (currentLim > 1f)
                currentLim -= .5f * OpenSpeed;
        }

        // using values to door object
        hingeLim.max = currentLim;
        hingeLim.min = -currentLim;
        hinge.limits = hingeLim;
    }
    
}
