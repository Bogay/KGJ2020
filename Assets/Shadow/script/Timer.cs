using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public int gameTime = 40;
    public static bool firstScene = true;
    public EasySurvivalScripts.PlayerMovement player;
    public GameObject now_player;
    public int time;
    public Text text;
    public string sceneName = "Mage_Room_Demo";
    bool start = false;
    public GameObject key_prefab_drop;
    // Start is called before the first frame update
    void Start()
    {
        //now_player.GetComponent<EasySurvivalScripts.PlayerMovement>().is_shadow = false;
        this.time = this.gameTime;
        text.text = this.gameTime.ToString();
       
    }

    // Update is called once per frame
    void Update()
    {
        key_prefab_drop = GameObject.Find("Door_key(Clone)");
        if (this.start == false)
        {
            StartCoroutine(this.CountDown());
            this.start = true;
        }
        if (this.time == 0)
        {
            this.Restart();
        }
        if (this.time == 1)
        {
            key_prefab_drop.transform.transform.parent = null;
            Debug.Log(key_prefab_drop.transform.position);
            ShadowSaver.keypos = key_prefab_drop.transform.position;
        }
        if (Input.GetKey(KeyCode.R))
        {
            this.Restart();
        }
    }
    IEnumerator CountDown()
    {
        for (this.time = this.gameTime; this.time > -1; this.time--)
        {
            text.text = this.time.ToString();
            yield return new WaitForSeconds(1);
        }
    }
    void Restart()
    {
       
        this.time = this.gameTime;
        text.text = "0";
        this.start = false;
        this.player.is_shadow = true;
        ShadowSaver.shadow2.Add(this.player.pointInTime);
        this.player.is_shadow = false;
        firstScene = false;
        SceneManager.LoadScene(this.sceneName);
    }
}
