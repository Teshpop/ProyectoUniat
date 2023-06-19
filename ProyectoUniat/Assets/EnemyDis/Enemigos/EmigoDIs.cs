using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDis : MonoBehaviour
{
    public Transform puntoInstancia;
    public GameObject bala;
    private float tiempo;
    private Transform jugador;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        tiempo += Time.deltaTime;

        // Calcular la dirección del jugador en relación a la torreta
        Vector2 direccion = jugador.position - transform.position;

        if (tiempo >= 2 && Mathf.Sign(direccion.x) == Mathf.Sign(transform.localScale.x))
        {
            Instantiate(bala, puntoInstancia.position, Quaternion.identity);
            tiempo = 0;
        }
    }
}

