using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyConter : MonoBehaviour
{
    [SerializeField] private BoxCollider2D Puerta;
    [SerializeField] private SpriteRenderer puertaObject;
    [SerializeField] public int keys, contador;

    private void Start()
    {
        PuertaAbierta();
    }

    public void keyAgarrado()
    {
        keys++;
        PlayerPrefs.SetInt("llavesSave", keys);
        Debug.Log(PlayerPrefs.GetInt("llavesSave"));
        PuertaAbierta();
    }

    private void PuertaAbierta()
    {
        if (PlayerPrefs.GetInt("llavesSave") >= contador)
        {
            Puerta.isTrigger = true;
            puertaObject.color = Color.white;
        }
    }
    
}
