using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallaWin : MonoBehaviour
{
    [SerializeField] private GameObject pantallawin;
    [SerializeField] private bool resetaearLlave;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerPrefs.DeleteAll();
            pantallawin.SetActive(true);
        }
    }
}
