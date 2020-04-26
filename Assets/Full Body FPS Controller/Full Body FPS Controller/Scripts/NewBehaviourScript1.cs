using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1
{
    public Vector3 pos;
    public Quaternion rotation;
    public float horizontal;
    public float vertical;
    public bool isGround;
    public bool jumpAnimation;
    public bool pressE;
    public NewBehaviourScript1(Vector3 pos, Quaternion rotation, float horizontal, float vertical, bool isGround, bool jumpAnimation, bool pressE)
    {
        this.pos = pos;
        this.rotation = rotation;
        this.horizontal = horizontal;
        this.vertical = vertical;
        this.isGround = isGround;
        this.jumpAnimation = jumpAnimation;
        this.pressE = pressE;
    }
}
