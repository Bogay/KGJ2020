using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Playgame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }
    public void Quitgame()
    {
        Application.Quit();
    }
    public void Intro()
    {
        SceneManager.LoadScene(3);
    }
    public void Back_to_menu()
    {
        Debug.Log("see");
        SceneManager.LoadScene(0);
    }

}
