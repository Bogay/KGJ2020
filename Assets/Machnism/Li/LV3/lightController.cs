using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightController : MonoBehaviour
{
    public bool standing = false;
    public Material lightMaterial, darkMaterial;
    MeshRenderer ren;
    // Start is called before the first frame update
    void Start()
    {
        this.ren = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.standing == true)
        {
            this.ren.material = this.lightMaterial;
        }
        else
        {
            this.ren.material = this.darkMaterial;
        }
    }
}
