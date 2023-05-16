using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemigo2D : MonoBehaviour
{
    public Enemigo2D enemigo;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            //print("Daño");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemigo.atacando = false;
            enemigo.GetComponent<Enemigo2D>().Final_Ani();
        }
    }


}
