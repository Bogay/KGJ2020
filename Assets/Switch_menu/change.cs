using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change : MonoBehaviour
{
    public Text changingText;
    public GameObject changingTextTwo;
    public GameObject changingText3;
    public GameObject changingText4;
       // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Textchange()
    {
        changingText.text = "2";
        changingTextTwo.GetComponent<Text>().text = "2";
        changingText3.GetComponent<Text>().text = "2";
        changingText4.GetComponent<Text>().text = "2";
    }
}
