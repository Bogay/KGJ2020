using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class colider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("switch");
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "shadow")
        {
            SceneManager.LoadScene(2);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
