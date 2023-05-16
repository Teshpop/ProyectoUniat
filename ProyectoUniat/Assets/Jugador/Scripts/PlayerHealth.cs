using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image hBar;
    public float hAct;
    public float hMax=100;
    void Start()
    {
        hAct = hMax;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TakeDmg(20);
        }
             
    }

    void TakeDmg(float a)
    {
        hAct -= a;
        hBar.fillAmount = hAct / hMax;
    }
}
