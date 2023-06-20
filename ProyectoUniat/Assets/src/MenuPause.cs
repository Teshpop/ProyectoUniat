using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject VideoPane;

    // Start is called before the first frame update
    void Start()
    {
        VideoPane.SetActive(false);
        PausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Video()
    {
        VideoPane.SetActive(true);
        PausePanel.SetActive(false);
    }

    public void Menu()
    {
        VideoPane.SetActive(false);
        PausePanel.SetActive(true); 
    }
}
