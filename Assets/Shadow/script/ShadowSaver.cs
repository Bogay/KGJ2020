using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSaver : MonoBehaviour
{
    public GameObject shadow_prefab;
    public static List<GameObject> shadow = new List<GameObject>();
    public static List<List<NewBehaviourScript1>> shadow2 = new List<List<NewBehaviourScript1>>();
    public static int a = 10;
    public Transform playerMap;
    public static Vector3 keypos = new Vector3(-5.723f, 10.647f, -13f);
    public GameObject key_prefab;
    public static GameObject key_clone;

    private void Start()
    {

        Debug.Log(keypos);
        key_clone = Instantiate(key_prefab, keypos, Quaternion.identity);
        
        
    }
    private void Awake()
    {
        /*foreach (GameObject sha in shadow)
        {
            Instantiate(sha, new Vector3(0f, 0.1f, -1f), Quaternion.identity);
        }*/
        if (Timer.firstScene == false)
        {
            foreach (List<NewBehaviourScript1> item in shadow2)
            {
                GameObject shadow = Instantiate(this.shadow_prefab, new Vector3(0f, 0.1f, -1f), Quaternion.identity, this.playerMap);
                shadow.GetComponent<EasySurvivalScripts.PlayerMovement>().pointInTime = new List<NewBehaviourScript1>(item);
                Debug.Log("Player" + shadow2.IndexOf(item) + " : " + item.Count);
                shadow.GetComponent<EasySurvivalScripts.PlayerMovement>().is_shadow = true;
            }

        }
    }
    
}
