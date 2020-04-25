using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text counter;
    public int count=0;
    // Start is called before the first frame update
    public void OnBtn0()
    {
        if (count > 9) count -= 10;
        count++;
        counter.text = "" + count;
    }
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
