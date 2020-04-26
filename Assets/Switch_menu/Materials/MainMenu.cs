using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void screenSceneSwitcher()
    {
     
        SceneManager.LoadScene(1);
    }
    public void quitgame()
    {
        Application.Quit();
    }

}
