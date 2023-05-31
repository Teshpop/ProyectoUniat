using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumoJefe : MonoBehaviour
{
    [SerializeField] private GameObject particulasHumo;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            particulasHumo.SetActive(false);
        }
    }
}
