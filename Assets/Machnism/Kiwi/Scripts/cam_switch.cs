using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_switch : MonoBehaviour
{
    public GameObject cam1, cam2; //兩個不同的攝影機
    public GameObject obj1, obj2; //兩個不同的GameObject
    public Timer sha;
    public bool first_pass = true;
    void Awake()
    {

        //預設先開啟第一部攝影機


        //一定要先暫停不使用的攝影機後，再開啟要使用的攝影機！
        cam2.SetActive(false);
        cam1.SetActive(true);

        //沒有要顯示出來的物件則先暫時關閉，同時開啟要顯示的物件，避免背景執行浪費效能。若多部攝影機都拍著同個物件，則不需要關閉該物件，只需關閉攝影機即可

        //被關閉的物件和其子物件都會被隱藏(其身上的script都會一起被暫停)
        obj2.SetActive(false);
        obj1.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((check_password.a[0] == 6 && check_password.a[1] == 0 && check_password.a[2] == 6 && check_password.a[3] == 0 && first_pass)||sha.time==0)
        {
            // 答對密碼切回主畫面

            AN_Button.is_passsword_door = 2;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cam1.SetActive(true);
            obj1.SetActive(true);
            cam2.SetActive(false);
            obj2.SetActive(false);
            first_pass = false;
        }
        else if (btn_return.rtrn)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            AN_Button.is_passsword_door = 0;
            btn_return.rtrn = false;
            cam1.SetActive(true);
            obj1.SetActive(true);
            cam2.SetActive(false);
            obj2.SetActive(false);
        }
        else if (AN_Button.is_passsword_door == 1)
        {
            // 觸發並開始解密碼
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cam2.SetActive(true);
            obj2.SetActive(true);
            cam1.SetActive(false);
            obj1.SetActive(false);
        }
    }

}
