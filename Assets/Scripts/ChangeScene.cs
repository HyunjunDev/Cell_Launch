using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(2560, 1440, true);
    }
    public void ClickStartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void clickMainButton()
    {
        SceneManager.LoadScene("Start");
    }
}
