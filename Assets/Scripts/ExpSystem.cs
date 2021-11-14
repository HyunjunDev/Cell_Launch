using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExpSystem : MonoBehaviour
{
    public float maxExp;
    public int updateExp;

    public Image expBar;
    public int playerLevel;

    public Text levelText;

    private void Start()
    {
        playerLevel = 1;
        maxExp = 20;
        updateExp = 0;
    }
    private void Update()
    {
        expBar.fillAmount = updateExp / maxExp;
        levelText.text = "Lv. " + playerLevel;
        if(updateExp>=maxExp)
        {
            playerLevel++;
            updateExp = 0;
            maxExp *= 1.5f;
        }
    }
}
