using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemigo2D : MonoBehaviour
{
    public Enemigo2D enemigo;
    private float hitLag=0;
    private bool airePolaco=false;
    private void Update()
    {
        if (!airePolaco)
        {
            hitLag += Time.deltaTime;
            if(hitLag >= 1)
            {
                hitLag= 0;
                airePolaco = true;
                enemigo.atacando = false;
            }
        }
        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            Debug.Log("Entrante");
            enemigo.atacando = true;
            //coll.GetComponent<PlayerMovement>().TakeDmg(10);
            //print("Daño");
            //GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D tocacion)
    {
        if (tocacion.CompareTag("Player"))
        {
            if (enemigo.atacando && airePolaco)
            {
                enemigo.atacando = false;
                tocacion.GetComponent<PlayerMovement>().TakeDmg(10);
                StartCoroutine(doWamacion());
                airePolaco = false;
                Debug.Log("Quedante");

            }
        }
        
    }
    /*void wamacion()
    {
        enemigo.atacando = true;
        hitLag= 1f;
        //GetComponent<BoxCollider2D>().enabled = true;
    }*/
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemigo.atacando = false;
            enemigo.Final_Ani();
            Debug.Log("Saliente");
        }
    }
    private IEnumerator doWamacion()
    { 
        yield return new WaitForSeconds(hitLag);
        enemigo.atacando = true;
        StopAllCoroutines();
        
        //yield return new WaitForSeconds(hitLag*2);
    }

}
