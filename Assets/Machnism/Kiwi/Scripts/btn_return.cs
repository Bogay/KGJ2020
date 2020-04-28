using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_return : MonoBehaviour
{
    public static bool rtrn = false;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Clickme);
    }

    // Update is called once per frame
    void Clickme()
    {
        Debug.Log("click");
        rtrn = true;
    }
}
