using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    public Transform fireP;
    public GameObject knifepref;
    public float time2Liv;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject KAct = Instantiate(knifepref, fireP.position,fireP.rotation);
        Destroy (KAct,time2Liv);
    }
}
