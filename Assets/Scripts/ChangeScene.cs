using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
    public void ClickGameExit()
    {
        Application.Quit();
    }

    public void ClickStartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void ClickMainButton()
    {
        SceneManager.LoadScene("Start");
    }

}
