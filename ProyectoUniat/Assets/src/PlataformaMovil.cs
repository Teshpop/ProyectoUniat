using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;
    private int i;
    void Start()
    {
        transform.position = points[startingPoint].position;//Asignar punto inicial
    }
    void Update()
    {
        //Revisar la distancia entre plataforma y puntos
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if(i==points.Length) 
            {
                i = 0; //reseteo de index
            }
        }
        //Mover la plataforma con index en points
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
