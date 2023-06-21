using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int attackDamage;
    public int enragedAttackDamage;
    public Transform pos;//atack point
    public bool Enranged=false;
    private float hitLagB=0;
    private bool contado=false;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    private void Update()
    {
        if (!contado)
        {
            hitLagB += Time.deltaTime;
            if (hitLagB >= 2)
            {
                hitLagB = 0;
                contado = true;
            }
        }

    }
    public void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos.position, attackRange, attackMask);
        foreach (Collider2D col in colliders)
        {
            if (col.name == "TestPlayer")
            {
                if (Enranged)
                {
                    col.GetComponent<PlayerMovement>().TakeDmg(enragedAttackDamage);
                    Debug.Log("Daño de boss:" + enragedAttackDamage);
                }
                else
                {
                    col.GetComponent<PlayerMovement>().TakeDmg(attackDamage);
                    Debug.Log("Daño de boss:" + attackDamage);
                }
            }
            
            Debug.Log(col.name);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name== "Col4Boss")
        {
            Debug.Log("Al alcance de boss");
            //Attack();
            gameObject.GetComponent<Boss>().canMoveB=false;
        }
    }
    private void OnTriggerStay2D(Collider2D tocacion)
    {
        if (tocacion.name == "Col4Boss")
        {
            if (contado)
            {
                StartCoroutine(doWamacion());
                contado = false;
                Debug.Log("Boss pegando");

            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<Boss>().canMoveB = true;
    }

    private void OnDrawGizmosSelected() //Debug
    {
        if (pos == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(pos.position, attackRange);
    }
    private IEnumerator doWamacion()
    {
        yield return new WaitForSeconds(hitLagB);
        Attack();
        StopAllCoroutines();

        //yield return new WaitForSeconds(hitLag*2);
    }
}



