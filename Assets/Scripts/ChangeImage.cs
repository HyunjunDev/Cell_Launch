using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeImage : MonoBehaviour
{
    public Image buttonPause;
    public GameObject panel;
    public Sprite pause;
    public Sprite start;
    public void ClickPauseButton()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1f;
            panel.SetActive(false);
            buttonPause.sprite = pause;
        }
        else
        {
            Time.timeScale = 0f;
            panel.SetActive(true);
            buttonPause.sprite = start;
        }
    }
}
