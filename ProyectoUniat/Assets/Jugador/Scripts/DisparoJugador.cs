using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    public Transform fireP;
    public GameObject knifepref;
    public float time2Liv;
    public float cooldownTime = 5f;
    private bool canShoot = true;

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && canShoot)
        {
            Shoot();
            StartCoroutine(Cooldown());
        }
    }

    void Shoot()
    {
        GameObject KAct = Instantiate(knifepref, fireP.position, fireP.rotation);
        Destroy(KAct, time2Liv);
    }

    IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }
}
