using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackP;
    public float attackR;
    public LayerMask enemyLayer;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }
    void Attack()
    {
        Debug.Log("Ataque");
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackP.position, attackR, enemyLayer);
        foreach (Collider2D enemy in hitEnemy)
        {
            //Debug c/enemigos
            Debug.Log("Golpeamos a" + enemy.name);
        }
    }

    //Debug
    private void OnDrawGizmosSelected()
    {
        if (attackP==null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackP.position, attackR);
    }
}
