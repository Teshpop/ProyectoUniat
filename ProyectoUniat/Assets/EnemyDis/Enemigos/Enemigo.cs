using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float tiempoEntreDisparos = 2f;
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public int Health = 10;
    public float BulletTime2Live;

    private Transform jugador;
    private float tiempoUltimoDisparo;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Si ha pasado suficiente tiempo desde el �ltimo disparo, disparar
        if (Time.time > tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Disparar()
    {
        // Calcular la direcci�n del jugador en relaci�n a la torreta
        Vector2 direccion = jugador.position - transform.position;
        direccion.Normalize();

        // Instanciar la bala en el punto de disparo y darle una velocidad inicial en la direcci�n correcta
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
        rbBala.velocity = direccion * 10f;

        // Establecer la rotaci�n del proyectil basada en la direcci�n de movimiento
        bala.transform.up = direccion;

        Destroy(bala, BulletTime2Live);
    }

    public void TakeDmg(int damage)
    {
        Health -= damage;
    }
}

