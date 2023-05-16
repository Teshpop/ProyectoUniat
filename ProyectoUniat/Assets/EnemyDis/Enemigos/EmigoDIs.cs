using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmigoDIs : MonoBehaviour
{
    public Transform puntoInstancia;
    public GameObject bala;
    private float tiempo;

    private void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= 2)
        {
            Instantiate(bala, puntoInstancia.position, Quaternion.identity);
            tiempo = 0;
        }
    }



}
