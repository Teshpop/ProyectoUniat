using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float maxHealth = 500;
    public float health;
    public GameObject deathEffect;
    public bool isInvulnerable = false;
    public GameObject Jefe;

    public GameObject VisualHBB;
    public Image BHBar;

    private void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        if (VisualHBB.active == false) { VisualHBB.SetActive(true); }
        if (isInvulnerable)
            return;

        health -= damage;
        Debug.Log("Boss took" + damage + "damage");
        float btmp = health / maxHealth;
        Debug.Log("Bar filled " + btmp);
        BHBar.fillAmount = btmp;

        if (health <= 200)
        {
            SetEnraged(true);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void SetEnraged(bool isEnraged)
    {
       gameObject.GetComponent<BossWeapon>().Enranged= isEnraged;
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(Jefe);
        VisualHBB.SetActive(true);
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Knife"))
        {
            TakeDamage(25);
            Destroy(col.gameObject);
        }
    }
}
