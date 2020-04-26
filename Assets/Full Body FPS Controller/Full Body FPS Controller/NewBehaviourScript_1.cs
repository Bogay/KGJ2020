using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript_1 : MonoBehaviour
{
    public Text counter1;
    public int count1 = 0;
    private Vector3 position;
    private Quaternion rotation;
    private float horzAnimation;
    private float vertAnimation;
    private bool landAnimation;
    private bool jumpAnimation;
    private bool pressE;

    public NewBehaviourScript_1(Vector3 position, Quaternion rotation, float horzAnimation, float vertAnimation, bool landAnimation, bool jumpAnimation, bool pressE)
    {
        this.position = position;
        this.rotation = rotation;
        this.horzAnimation = horzAnimation;
        this.vertAnimation = vertAnimation;
        this.landAnimation = landAnimation;
        this.jumpAnimation = jumpAnimation;
        this.pressE = pressE;
    }

    // Start is called before the first frame update
    public void OnBtn()
    {
        count1++;
        if (count1 > 9) count1 -= 10;
        counter1.text = "" + count1;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
