using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public Text counter1;
    public int count1 = 0;
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
