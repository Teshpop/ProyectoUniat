using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoEnemigo2D : MonoBehaviour
{
    public Animator ani;
    public Enemigo2D enemigo;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            //enemigo.atacando = true;
            //GetComponent<BoxCollider2D>().enabled = false;
            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack", true);
            Invoke("Atacarx2", 1f);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //enemigo.atacando = false;
            enemigo.GetComponent<Enemigo2D>().Final_Ani(); //atacando se vuelve false
        }
    }

    void Atacarx2()
    {
        enemigo.atacando = true;
        //GetComponent<BoxCollider2D>().enabled = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
