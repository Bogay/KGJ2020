using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class check_password : MonoBehaviour
{
    public int[] a = { 0, 0, 0, 0 };
    public void Botton_onclick0()
    {
        if (a[0] > 9) a[0] -= 10;
        a[0]++;
    }
    public void Botton_onclick1()
    {
        if (a[1] > 9) a[1] -= 10;
        a[1]++;
    }
    public void Botton_onclick2()
    {
        if (a[2] > 9) a[2] -= 10;
        a[2]++;
    }
    public void Botton_onclick3()
    {
        if (a[3] > 9) a[3] -= 10;
        a[3]++;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (a[0] == 6 && a[1] == 0 && a[2] == 6 && a[3] == 0)
            AN_Button.is_passsword_door = 2;
    }
}
