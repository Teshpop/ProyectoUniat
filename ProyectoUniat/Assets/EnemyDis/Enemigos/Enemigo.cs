using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemigo : MonoBehaviour
{
    public float tiempoEntreDisparos = 2f;
    public GameObject Enemy;
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public int Health=10;
    private float tiempoUltimoDisparo;
    public float BulletTime2Live;
    

    private void Update()
    {
        // Si ha pasado suficiente tiempo desde el último disparo, disparar
        if (Time.time > tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
        if (Health <= 0)
        {
            Destroy(Enemy);
        }
    }

    private void Disparar()
    {
        // Instanciar la bala en el punto de disparo y darle una velocidad inicial
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
        rbBala.velocity = Vector2.left * 10f;

        Destroy(bala, BulletTime2Live);

    }
    
    public void TakeDmg(int a)
    {
        Health -= a;
    }    
}

