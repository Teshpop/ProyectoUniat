using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   
    public GameObject MenuPrin;
    public GameObject MenuConfig;
    public GameObject MenuVideo;
    public GameObject MenuGame;

    void Start()
    {
        MenuPrin.SetActive(true);
        MenuConfig.SetActive(false);
        MenuVideo.SetActive(false);
        MenuGame.SetActive(false);
    }

    public void play(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void ActiveMenuConfig(bool active){
        if(active){
            MenuConfig.SetActive(true);
            MenuPrin.SetActive(false);
        }else{
            MenuConfig.SetActive(false);
            MenuPrin.SetActive(true);
        }
    }

    public void ActiveMenuGame(bool active){
        if(active){
            MenuConfig.SetActive(false);
            MenuGame.SetActive(true);
        }else{
            MenuConfig.SetActive(true);
            MenuGame.SetActive(false);
        }
    }

    public void ActiveMenuVideo(bool active){
        if(active){
            MenuConfig.SetActive(false);
            MenuVideo.SetActive(true);
        }else{
            MenuConfig.SetActive(true);
            MenuVideo.SetActive(false);
        }
    }

    public void ActiveMenuSound(bool active){
        //Pendiente
    }
}
