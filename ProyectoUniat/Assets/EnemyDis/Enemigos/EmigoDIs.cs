using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDis : MonoBehaviour
{
    public Transform puntoInstancia;
    public GameObject balaPrefab;
    private float tiempo;
    private Transform jugador;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        tiempo += Time.deltaTime;

        // Calcular la direcci�n del jugador en relaci�n a la torreta
        Vector2 direccion = jugador.position - transform.position;

        if (tiempo >= 2 && Mathf.Sign(direccion.x) == Mathf.Sign(transform.localScale.x))
        {
            // Instanciar la bala
            GameObject bala = Instantiate(balaPrefab, puntoInstancia.position, Quaternion.identity);

            // Calcular el �ngulo de rotaci�n en grados
            float angle = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

            // Rotar el sprite del proyectil seg�n el �ngulo de rotaci�n
            SpriteRenderer spriteRenderer = bala.GetComponent<SpriteRenderer>();
            spriteRenderer.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            tiempo = 0;
        }
    }
}


